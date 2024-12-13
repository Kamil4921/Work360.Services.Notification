using MediatR;
using Work360.Services.Notification.Application.DTO;

namespace Work360.Services.Notification.Application.Queries;

[Contract]
public class GetNotification(Guid notificationId) : IRequest<NotificationDto>
{
    public Guid NotificationId { get; } = notificationId;
}