using SkillBridge.Application.DTOs.User;
using SkillBridge.Core.Entities;
using SkillBridge.Core.Interfaces;

namespace SkillBridge.Application.Services;

public class UserService
{
    private readonly IUnitOfWork _uow;

    public UserService(IUnitOfWork uow)
    {
        _uow = uow;
    }

    // ── GET ALL USERS (Profile Gallery) ───────────────
    public async Task<List<UserProfileDto>> GetAllUsersAsync()
    {
        var users = await _uow.Users.GetAllAsync();
        return users.Select(MapToDto).ToList();
    }

    // ── GET USER BY ID ────────────────────────────────
    public async Task<UserProfileDto?> GetUserByIdAsync(int userId)
    {
        var user = await _uow.Users.GetByIdAsync(userId);
        return user == null ? null : MapToDto(user);
    }

    // ── UPDATE PROFILE ────────────────────────────────
    public async Task<UserProfileDto?> UpdateProfileAsync(int userId, UpdateProfileDto dto)
    {
        var user = await _uow.Users.GetByIdAsync(userId);
        if (user == null) return null;

        if (!string.IsNullOrEmpty(dto.FullName))
            user.FullName = dto.FullName;
        if (!string.IsNullOrEmpty(dto.Department))
            user.Department = dto.Department;
        if (dto.Year.HasValue)
            user.Year = dto.Year;
        if (!string.IsNullOrEmpty(dto.Bio))
            user.Bio = dto.Bio;
        if (!string.IsNullOrEmpty(dto.Contact))
            user.Contact = dto.Contact;

        // Update skills
        if (dto.Skills.Any())
        {
            user.UserSkills.Clear();
            foreach (var s in dto.Skills)
            {
                user.UserSkills.Add(new UserSkill
                {
                    UserId = userId,
                    SkillId = s.SkillId,
                    Proficiency = s.Proficiency
                });
            }
        }

        _uow.Users.Update(user);
        await _uow.SaveChangesAsync();

        return MapToDto(user);
    }

    // ── MAPPER ────────────────────────────────────────
    private static UserProfileDto MapToDto(User user) => new()
    {
        UserId = user.UserId,
        FullName = user.FullName,
        Email = user.Email,
        Department = user.Department,
        Year = user.Year,
        Bio = user.Bio,
        Contact = user.Contact,
        IsVerified = user.IsVerified,
        CreatedAt = user.CreatedAt,
        Skills = user.UserSkills.Select(us => new UserSkillDto
        {
            SkillId = us.SkillId,
            SkillName = us.Skill?.Name ?? "",
            Category = us.Skill?.Category ?? "",
            Proficiency = us.Proficiency
        }).ToList()
    };
}