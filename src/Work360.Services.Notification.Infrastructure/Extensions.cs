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
        var options = new CosmosClientOptions
        {
            HttpClientFactory = () =>
            {
                HttpMessageHandler httpMessageHandler = new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback =
                        HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                };
                return new HttpClient(httpMessageHandler);
            },
            ConnectionMode = ConnectionMode.Gateway,
            LimitToEndpoint = true
        };
        services.AddSingleton<IEventMapper, EventMapper>();
        services.AddSingleton<IMessageBroker, MessageBroker>();
        services.AddSingleton<CosmosClient>(_ => new CosmosClient("https://localhost:2500", "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==", options));
        services.AddTransient<ISendService, SendService>();
        services.AddTransient<INotificationRepository, NotificationRepository>();
        services.AddTransient<ILeaveRepository, LeaveRepository>();
        services.AddScoped<ServiceBusMessageReceiver>();
        
        services.AddScoped(sp => new CosmosDbContext(sp.GetRequiredService<CosmosClient>(), "work360-Notification"));
        
        return services;
    }
    
    //
}