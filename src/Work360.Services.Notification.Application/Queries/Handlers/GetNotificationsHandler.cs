using MediatR;
using Work360.Services.Notification.Application.DTO;
using Work360.Services.Notification.Core.Repositories;

namespace Work360.Services.Notification.Application.Queries.Handlers;

public class GetNotificationsHandler(INotificationRepository notificationRepository) : IRequestHandler<GetNotifications, IEnumerable<NotificationDto>>
{
    public async Task<IEnumerable<NotificationDto>> Handle(GetNotifications request, CancellationToken cancellationToken)
    {
        var notifications = await notificationRepository.GetNotifications();
        var notificationsDto = notifications.Select(notification => new NotificationDto(notification)).ToList();
        
        return notificationsDto;
    }
}