using MediatR;
using Work360.Services.Notification.Application.DTO;

namespace Work360.Services.Notification.Application.Queries.Handlers;

public class GetNotificationHandler : IRequestHandler<GetNotification, NotificationDto>
{
    public Task<NotificationDto> Handle(GetNotification request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}