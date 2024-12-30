namespace Work360.Services.Notification.Core.Repositories;

public interface INotificationRepository
{
    Task<Entities.Notification> GetNotification(Guid id);
    Task<IEnumerable<Entities.Notification>> GetNotifications();
    Task AddNotification(Entities.Notification notification);
    Task DeleteNotification(Guid id);
}