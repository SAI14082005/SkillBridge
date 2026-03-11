namespace SkillBridge.Core.Entities;

public class UserSkill
{
    public int UserId { get; set; }
    public int SkillId { get; set; }
    public string Proficiency { get; set; } = "Intermediate"; // Beginner / Intermediate / Expert

    // Navigation Properties
    public User User { get; set; } = null!;
    public Skill Skill { get; set; } = null!;
}