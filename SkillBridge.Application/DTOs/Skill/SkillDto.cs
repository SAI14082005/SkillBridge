namespace SkillBridge.Application.DTOs.Skill;

public class SkillDto
{
    public int SkillId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Category { get; set; }
}