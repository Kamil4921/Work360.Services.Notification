using MediatR;
using Work360.Services.Notification.Application.DTO;

namespace Work360.Services.Notification.Application.Queries;

public class GetNotification(Guid notificationId) : IRequest<NotificationDto>
{
    public Guid NotificationId { get; } = notificationId;
}