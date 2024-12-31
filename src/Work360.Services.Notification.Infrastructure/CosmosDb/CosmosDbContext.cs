using Microsoft.Azure.Cosmos;

namespace Work360.Services.Notification.Infrastructure.CosmosDb;

public class CosmosDbContext(CosmosClient cosmosClient, string databaseName)
{
    public Container NotificationsContainer { get; } = cosmosClient.GetContainer(databaseName, "notifications");
    public Container LeavesContainer { get; } = cosmosClient.GetContainer(databaseName, "leaves");
}