namespace Work360.Services.Notification.Core.Events;

public class NotificationCreated(Entities.Notification notification) : IDomainEvent
{
    public Entities.Notification Notification { get; } = notification;
}