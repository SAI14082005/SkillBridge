namespace SkillBridge.Application.DTOs.User;

public class UserProfileDto
{
    public int UserId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string? Department { get; set; }
    public int? Year { get; set; }
    public string? Bio { get; set; }
    public string? Contact { get; set; }
    public bool IsVerified { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<UserSkillDto> Skills { get; set; } = new();
}

public class UserSkillDto
{
    public int SkillId { get; set; }
    public string SkillName { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Proficiency { get; set; } = string.Empty;
}