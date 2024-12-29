using Microsoft.Azure.Cosmos;

namespace Work360.Services.Notification.Infrastructure.CosmosDb;

public class CosmosDbContext(CosmosClient cosmosClient, string databaseName, string containerName)
{
    public Container Container { get; } = cosmosClient.GetContainer(databaseName, containerName);
}