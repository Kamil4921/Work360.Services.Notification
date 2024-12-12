using System.Net.Mail;
using MediatR;

namespace Work360.Services.Notification.Application.Commands.Handlers;

public class SendNotificationHandler : IRequestHandler<SendNotification, Guid>
{
    public Task<Guid> Handle(SendNotification request, CancellationToken cancellationToken)
    {
        var client = new SmtpClient("localhost");

        var mailMessage = new MailMessage
        {
            From = new MailAddress("work360@work360.com"),
            Subject = request.Notification.Title,
            Body = request.Notification.Text,
            IsBodyHtml = true,
        };
        mailMessage.To.Add(request.Notification.Email);
        client.Send(mailMessage);

        return Task.FromResult(request.Notification.Id);
    }
}