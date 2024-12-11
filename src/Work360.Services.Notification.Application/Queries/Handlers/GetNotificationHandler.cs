using MediatR;
using Work360.Services.Notification.Application.DTO;
using Work360.Services.Notification.Application.Exceptions;
using Work360.Services.Notification.Core.Repositories;

namespace Work360.Services.Notification.Application.Queries.Handlers;

public class GetNotificationHandler(INotificationRepository notificationRepository) : IRequestHandler<GetNotification, NotificationDto>
{
    public async Task<NotificationDto> Handle(GetNotification request, CancellationToken cancellationToken)
    {
        var notification = await notificationRepository.GetNotification(request.NotificationId);
        if (notification is null)
        {
            throw new NotificationNotFoundException(request.NotificationId);
        }

        var notificationDto = new NotificationDto(notification);

        return notificationDto;
    }
}