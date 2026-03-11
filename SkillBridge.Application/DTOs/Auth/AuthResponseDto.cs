namespace SkillBridge.Application.DTOs.Auth;

public class AuthResponseDto
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public string? Token { get; set; }
    public int? UserId { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
}