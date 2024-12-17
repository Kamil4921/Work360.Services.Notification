using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.DependencyInjection;
using Work360.Services.Notification.Infrastructure.CosmosDb;

namespace Work360.Services.Notification.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<CosmosClient>(sp => new CosmosClient("https://localhost:2500", "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw=="));

        services.AddScoped(sp => new CosmosDbContext(sp.GetRequiredService<CosmosClient>(), "work360-Notification", "notifications"));
        
        return services;
    }
}