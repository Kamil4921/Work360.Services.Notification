using MediatR;

namespace Work360.Services.Notification.Application.Events;

public class NotificationSent(Guid notificationId, string recipient) : INotification
{
    public Guid NotificationId { get; } = notificationId;
    public string Recipient { get; } = recipient;
}