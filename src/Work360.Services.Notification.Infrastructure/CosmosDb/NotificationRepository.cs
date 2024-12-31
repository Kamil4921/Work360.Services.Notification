using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Work360.Services.Notification.Core.Repositories;

namespace Work360.Services.Notification.Infrastructure.CosmosDb;

public class NotificationRepository(CosmosDbContext context) : INotificationRepository
{
    public async Task<Core.Entities.Notification> GetNotification(Guid id)
    {
        return await context.NotificationsContainer.ReadItemAsync<Core.Entities.Notification>(id.ToString(), new PartitionKey(id.ToString()));
    }

    public async Task<IEnumerable<Core.Entities.Notification>> GetNotifications()
    {
        var iterator = context.NotificationsContainer.GetItemLinqQueryable<Core.Entities.Notification>().ToFeedIterator();
        var notifications = new List<Core.Entities.Notification>();

        while (iterator.HasMoreResults)
        {
            var response = await iterator.ReadNextAsync();
            notifications.AddRange(response);
        }

        return notifications;
    }

    public async Task AddNotification(Core.Entities.Notification notification)
    {
        await context.NotificationsContainer.CreateItemAsync(notification);
    }
    
    public async Task DeleteNotification(Guid id)
    {
        await context.NotificationsContainer.DeleteItemAsync<Core.Entities.Notification>(id.ToString(),
            new PartitionKey(id.ToString()));
    }
}