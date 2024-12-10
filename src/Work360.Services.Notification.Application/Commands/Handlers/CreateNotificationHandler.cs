using MediatR;

namespace Work360.Services.Notification.Application.Commands.Handlers;

public class CreateNotificationHandler : IRequestHandler<CreateNotification, Guid>
{
    public Task<Guid> Handle(CreateNotification request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}