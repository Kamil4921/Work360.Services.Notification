using MediatR;

namespace Work360.Services.Notification.Application.Commands.Handlers;

public class SendNotificationHandler : IRequestHandler<SendNotification, Guid>
{
    public Task<Guid> Handle(SendNotification request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}