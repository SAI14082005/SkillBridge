namespace SkillBridge.Core.Entities;

public class TeamRequest
{
    public int RequestId { get; set; }
    public int ProjectId { get; set; }
    public int SenderId { get; set; }
    public int ReceiverId { get; set; }
    public string Status { get; set; } = "Pending"; // Pending / Accepted / Rejected
    public string? Message { get; set; }
    public DateTime SentAt { get; set; } = DateTime.UtcNow;
    public DateTime? RespondedAt { get; set; }

    // Navigation Properties
    public Project Project { get; set; } = null!;
    public User Sender { get; set; } = null!;
    public User Receiver { get; set; } = null!;
}