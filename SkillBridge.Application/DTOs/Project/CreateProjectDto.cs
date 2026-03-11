using System.ComponentModel.DataAnnotations;

namespace SkillBridge.Application.DTOs.Project;

public class CreateProjectDto
{
    [Required]
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public List<int> RequiredSkillIds { get; set; } = new();
}