using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Microsoft.Extensions.Configuration;

namespace SkillBridge.Application.Services;

public class EmailService
{
    private readonly IConfiguration _config;

    public EmailService(IConfiguration config)
    {
        _config = config;
    }

    public async Task<string> SendOtpEmailAsync(string toEmail)
    {
        var emailSettings = _config.GetSection("EmailSettings");

        // Generate OTP code
        var otpCode = new Random().Next(100000, 999999).ToString();

        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(
            emailSettings["SenderName"],
            emailSettings["SenderEmail"]));
        message.To.Add(MailboxAddress.Parse(toEmail));
        message.Subject = "SkillBridge — Your Verification Code";

        message.Body = new TextPart("html")
        {
            Text = $@"
                <div style='font-family: Arial, sans-serif; max-width: 500px; margin: auto;'>
                    <h2 style='color: #4F46E5;'>SkillBridge Verification</h2>
                    <p>Your one-time verification code is:</p>
                    <div style='font-size: 36px; font-weight: bold;
                                color: #4F46E5; letter-spacing: 8px;
                                padding: 20px; background: #F3F4F6;
                                text-align: center; border-radius: 8px;'>
                        {otpCode}
                    </div>
                    <p style='color: #6B7280; margin-top: 16px;'>
                        This code expires in <strong>10 minutes</strong>.
                        Do not share it with anyone.
                    </p>
                    <hr style='border: none; border-top: 1px solid #E5E7EB;'/>
                    <p style='color: #9CA3AF; font-size: 12px;'>
                        SkillBridge — Student Collaboration Platform
                    </p>
                </div>"
        };

        using var smtp = new SmtpClient();

        // ── Fix: Accept all SSL certificates in development ──
        smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;

        await smtp.ConnectAsync(
            emailSettings["Host"],
            int.Parse(emailSettings["Port"]!),
            SecureSocketOptions.StartTls);

        await smtp.AuthenticateAsync(
            emailSettings["SenderEmail"],
            emailSettings["SenderPassword"]);

        await smtp.SendAsync(message);
        await smtp.DisconnectAsync(true);

        // Return OTP so AuthService can save it to DB
        return otpCode;
    }
}