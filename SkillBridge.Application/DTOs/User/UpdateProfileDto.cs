namespace SkillBridge.Application.DTOs.User;

public class UpdateProfileDto
{
    public string? FullName { get; set; }
    public string? Department { get; set; }
    public int? Year { get; set; }
    public string? Bio { get; set; }
    public string? Contact { get; set; }
    public List<UpdateSkillDto> Skills { get; set; } = new();
}

public class UpdateSkillDto
{
    public int SkillId { get; set; }
    public string Proficiency { get; set; } = "Intermediate";
}