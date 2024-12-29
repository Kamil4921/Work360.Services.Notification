using Work360.Services.Notification.Core.Repositories;

namespace Work360.Services.Notification.Infrastructure.CosmosDb;

public class NotificationRepository : INotificationRepository
{
    public Task<Core.Entities.Notification> GetNotification(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Core.Entities.Notification>> GetNotifications()
    {
        throw new NotImplementedException();
    }

    public Task AddNotification(Core.Entities.Notification notification)
    {
        throw new NotImplementedException();
    }

    public Task UpdateNotification(Core.Entities.Notification notification)
    {
        throw new NotImplementedException();
    }

    public Task DeleteNotification(Guid id)
    {
        throw new NotImplementedException();
    }
}