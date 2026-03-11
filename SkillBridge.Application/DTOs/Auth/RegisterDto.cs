using System.ComponentModel.DataAnnotations;

namespace SkillBridge.Application.DTOs.Auth;

public class RegisterDto
{
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string FullName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
        ErrorMessage = "Password must be 8+ chars with uppercase, lowercase, number and special character. Example: Saiprasad@1234")]
    public string Password { get; set; } = string.Empty;

    public string? Department { get; set; }
    public int? Year { get; set; }
    public string? Bio { get; set; }
}