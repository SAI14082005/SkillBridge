namespace SkillBridge.Core.Entities;

public class User
{
    public int UserId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string? Department { get; set; }
    public int? Year { get; set; }
    public string? Bio { get; set; }
    public string? Contact { get; set; }
    public bool IsVerified { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation Properties
    public ICollection<UserSkill> UserSkills { get; set; } = new List<UserSkill>();
    public ICollection<Project> OwnedProjects { get; set; } = new List<Project>();
    public ICollection<TeamRequest> SentRequests { get; set; } = new List<TeamRequest>();
    public ICollection<TeamRequest> ReceivedRequests { get; set; } = new List<TeamRequest>();
}