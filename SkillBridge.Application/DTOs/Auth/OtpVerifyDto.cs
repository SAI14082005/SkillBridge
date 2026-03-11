using System.ComponentModel.DataAnnotations;

namespace SkillBridge.Application.DTOs.Auth;

public class OtpVerifyDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string OtpCode { get; set; } = string.Empty;
}