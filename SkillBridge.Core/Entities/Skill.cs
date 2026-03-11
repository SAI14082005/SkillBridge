namespace SkillBridge.Core.Entities;

public class Skill
{
    public int SkillId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Category { get; set; }

    // Navigation Properties
    public ICollection<UserSkill> UserSkills { get; set; } = new List<UserSkill>();
    public ICollection<ProjectSkill> ProjectSkills { get; set; } = new List<ProjectSkill>();
}