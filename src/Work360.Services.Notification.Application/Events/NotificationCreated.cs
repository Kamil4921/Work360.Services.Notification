using MediatR;

namespace Work360.Services.Notification.Application.Events;

public class NotificationCreated(Guid notificationId) : INotification
{
    public Guid NotificationId { get; } = notificationId;
}