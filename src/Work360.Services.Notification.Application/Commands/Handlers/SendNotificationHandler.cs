using MediatR;
using Work360.Services.Notification.Application.Services;

namespace Work360.Services.Notification.Application.Commands.Handlers;

public class SendNotificationHandler(ISendService sendService) : IRequestHandler<SendNotification, Guid>
{
    public async Task<Guid> Handle(SendNotification request, CancellationToken cancellationToken)
    {
        await sendService.SendEmail(request.Notification, "");

        return request.Notification.Id;
    }
}