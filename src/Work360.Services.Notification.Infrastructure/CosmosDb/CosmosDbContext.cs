using Microsoft.Azure.Cosmos;

namespace Work360.Services.Notification.Infrastructure.CosmosDb;

public class CosmosDbContext
{
    private readonly Container _container;

    public CosmosDbContext(CosmosClient cosmosClient, string databaseName, string containerName)
    {
        _container = cosmosClient.GetContainer(databaseName, containerName);
    }
}