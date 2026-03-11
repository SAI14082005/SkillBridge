namespace SkillBridge.Core.Entities;

public class Project
{
    public int ProjectId { get; set; }
    public int OwnerId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Status { get; set; } = "Open"; // Open / InProgress / Closed
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // Navigation Properties
    public User Owner { get; set; } = null!;
    public ICollection<ProjectSkill> ProjectSkills { get; set; } = new List<ProjectSkill>();
    public ICollection<TeamRequest> TeamRequests { get; set; } = new List<TeamRequest>();
}