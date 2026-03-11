namespace SkillBridge.Core.Entities;

public class ProjectSkill
{
    public int ProjectId { get; set; }
    public int SkillId { get; set; }

    // Navigation Properties
    public Project Project { get; set; } = null!;
    public Skill Skill { get; set; } = null!;
}