using System.Net.Mail;
using Work360.Services.Notification.Application.Services;

namespace Work360.Services.Notification.Infrastructure.Services;

public class SendService : ISendService
{
    public Task SendEmail(Core.Entities.Notification notification)
    {
        var client = new SmtpClient("localhost");

        var mailMessage = new MailMessage
        {
            From = new MailAddress("work360@work360.com"),
            Subject = notification.Title,
            Body = notification.Text,
            IsBodyHtml = true,
        };
        mailMessage.To.Add(notification.Email);
        client.Send(mailMessage);
        
        return Task.CompletedTask;
    }
}