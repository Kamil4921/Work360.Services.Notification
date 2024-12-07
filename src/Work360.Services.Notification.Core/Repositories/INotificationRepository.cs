namespace Work360.Services.Notification.Core.Repositories;

public interface INotificationRepository
{
    Task<Entities.Notification> GetNotification(Guid id);
    Task<IEnumerable<Entities.Notification>> GetNotification();
    Task AddNotification(Entities.Notification notification);
    Task UpdateNotification(Entities.Notification notification);
    Task DeleteNotification(Guid id);
}