using MediatR;
using Work360.Services.Notification.Application.DTO;

namespace Work360.Services.Notification.Application.Queries.Handlers;

public class GetNotificationsHandler : IRequestHandler<GetNotifications, IEnumerable<NotificationDto>>
{
    public Task<IEnumerable<NotificationDto>> Handle(GetNotifications request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}