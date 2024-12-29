using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.DependencyInjection;
using Work360.Services.Notification.Application.Services;
using Work360.Services.Notification.Core.Repositories;
using Work360.Services.Notification.Infrastructure.CosmosDb;
using Work360.Services.Notification.Infrastructure.Services;

namespace Work360.Services.Notification.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<CosmosClient>(_ => new CosmosClient("https://localhost:2500", "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw=="));
        services.AddTransient<ISendService, SendService>();
        services.AddTransient<INotificationRepository, NotificationRepository>();
        
        services.AddScoped(sp => new CosmosDbContext(sp.GetRequiredService<CosmosClient>(), "work360-Notification", "notifications"));
        
        return services;
    }
}