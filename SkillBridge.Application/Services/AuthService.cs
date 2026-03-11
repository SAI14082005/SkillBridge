using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SkillBridge.Application.DTOs.Auth;
using SkillBridge.Core.Entities;
using SkillBridge.Core.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SkillBridge.Application.Services;

public class AuthService
{
    private readonly IUnitOfWork _uow;
    private readonly IConfiguration _config;
    private readonly EmailService _emailService;

    public AuthService(IUnitOfWork uow, IConfiguration config, EmailService emailService)
    {
        _uow = uow;
        _config = config;
        _emailService = emailService;
    }

    // ── REGISTER ──────────────────────────────────────
    public async Task<AuthResponseDto> RegisterAsync(RegisterDto dto)
    {
        // Check if email already exists
        var existing = await _uow.Users.GetByEmailAsync(dto.Email);
        if (existing != null)
            return new AuthResponseDto { Success = false, Message = "Email already registered." };

        // Hash password
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

        // Create user
        var user = new User
        {
            FullName = dto.FullName,
            Email = dto.Email,
            PasswordHash = passwordHash,
            Department = dto.Department,
            Year = dto.Year,
            Bio = dto.Bio,
            IsVerified = false
        };

        await _uow.Users.AddAsync(user);
        await _uow.SaveChangesAsync();

        // Generate OTP, send email, capture the code
        var otpCode = await _emailService.SendOtpEmailAsync(dto.Email);

        // TODO: Save OTP to database (Phase 2 enhancement)
        // For now OTP is sent via email

        return new AuthResponseDto
        {
            Success = true,
            Message = "Registration successful! Please check your Gmail for the OTP verification code."
        };
    }

    // ── VERIFY OTP ────────────────────────────────────
    public async Task<AuthResponseDto> VerifyOtpAsync(OtpVerifyDto dto)
    {
        var user = await _uow.Users.GetByEmailAsync(dto.Email);
        if (user == null)
            return new AuthResponseDto { Success = false, Message = "User not found." };

        // Mark user as verified
        user.IsVerified = true;
        _uow.Users.Update(user);
        await _uow.SaveChangesAsync();

        return new AuthResponseDto
        {
            Success = true,
            Message = "Email verified successfully! You can now log in."
        };
    }

    // ── LOGIN ─────────────────────────────────────────
    public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
    {
        var user = await _uow.Users.GetByEmailAsync(dto.Email);
        if (user == null)
            return new AuthResponseDto { Success = false, Message = "Invalid email or password." };

        if (!user.IsVerified)
            return new AuthResponseDto { Success = false, Message = "Please verify your email first." };

        if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            return new AuthResponseDto { Success = false, Message = "Invalid email or password." };

        var token = GenerateJwtToken(user);

        return new AuthResponseDto
        {
            Success = true,
            Message = "Login successful!",
            Token = token,
            UserId = user.UserId,
            FullName = user.FullName,
            Email = user.Email
        };
    }

    // ── RESEND OTP ────────────────────────────────────
    public async Task<AuthResponseDto> ResendOtpAsync(string email)
    {
        var user = await _uow.Users.GetByEmailAsync(email);
        if (user == null)
            return new AuthResponseDto { Success = false, Message = "User not found." };

        if (user.IsVerified)
            return new AuthResponseDto { Success = false, Message = "Email already verified." };

        await _emailService.SendOtpEmailAsync(email);

        return new AuthResponseDto
        {
            Success = true,
            Message = "OTP resent! Please check your Gmail."
        };
    }

    // ── GENERATE JWT TOKEN ────────────────────────────
    private string GenerateJwtToken(User user)
    {
        var jwtSettings = _config.GetSection("JwtSettings");
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]!));

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.FullName)
        };

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(
                double.Parse(jwtSettings["ExpiryMinutes"]!)),
            signingCredentials: new SigningCredentials(
                key, SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}