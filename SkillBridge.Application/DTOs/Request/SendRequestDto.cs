using System.ComponentModel.DataAnnotations;

namespace SkillBridge.Application.DTOs.Request;

public class SendRequestDto
{
    [Required]
    public int ProjectId { get; set; }
    [Required]
    public int ReceiverId { get; set; }
    public string? Message { get; set; }
}