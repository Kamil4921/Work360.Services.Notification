using Azure.Messaging.ServiceBus;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Work360.Services.Notification.Application.Commands;
using Work360.Services.Notification.Application.DTO;

namespace Work360.Services.Notification.Infrastructure.Services;

public class ServiceBusMessageReceiver (ISender mediator, ILogger<ServiceBusMessageReceiver> logger)
{
    private const string ConnectionString = "Endpoint=sb://localhost:5672/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=RootManageSharedAccessKeyValue;UseDevelopmentEmulator=true;";
    private const string TopicName = "employee-topic";
    private const string SubscriptionName = "subscription.4";

    public async Task StartAsync()
    {
        var client = new ServiceBusClient(ConnectionString);
        var processor = client.CreateProcessor(TopicName, SubscriptionName, new ServiceBusProcessorOptions());

        processor.ProcessMessageAsync += MessageHandler;
        processor.ProcessErrorAsync += ErrorHandler;
        logger.LogInformation("Starting service bus");
        await processor.StartProcessingAsync();
    }

    private async Task MessageHandler(ProcessMessageEventArgs args)
    {
        var leave = JsonConvert.DeserializeObject<LeaveDto>(args.Message.Body.ToString())?? throw new ArgumentNullException();
        await mediator.Send(new CreateLeave(leave.LeaveId, leave.EmployeeId, leave.LeaveStart, leave.LeaveDuration));
        await mediator.Send(new CreateNotification($"{leave.EmployeeId} took leave from {leave.LeaveStart.Date} to {leave.LeaveStart.Date.AddDays(leave.LeaveDuration)}", $"{leave.EmployeeId} on leave"));
    }

    private Task ErrorHandler(ProcessErrorEventArgs args)
    {
        logger.LogError("Error occured in the topic");
        //TODO:Add monitoring
        return Task.CompletedTask;
    }
}