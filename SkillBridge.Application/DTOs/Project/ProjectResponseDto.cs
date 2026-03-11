namespace SkillBridge.Application.DTOs.Project;

public class ProjectResponseDto
{
    public int ProjectId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public string OwnerName { get; set; } = string.Empty;
    public int OwnerId { get; set; }
    public List<string> RequiredSkills { get; set; } = new();
}