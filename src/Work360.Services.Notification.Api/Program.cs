using MediatR;
using Work360.Services.Notification.Application;
using Work360.Services.Notification.Application.Queries;
using Work360.Services.Notification.Infrastructure;
using Work360.Services.Notification.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var scope = app.Services.CreateScope();
var scopedServiceBusReceiver = scope.ServiceProvider.GetRequiredService<ServiceBusMessageReceiver>();
await scopedServiceBusReceiver.StartAsync();

app.MapGet("/notification", async (ISender mediator, Guid id) => await mediator.Send(new GetNotification(id)))
    .WithOpenApi()
    .WithName("GetNotification");

app.MapGet("/notifications", async (ISender mediator) => 
        await mediator.Send(new GetNotifications()))
    .WithOpenApi()
    .WithName("GetNotifications");

app.MapGet("/leave", async (ISender mediator, Guid id) => 
        await mediator.Send(new GetLeave(id)))
    .WithOpenApi()
    .WithName("GetLeave");

app.MapGet("/leaves", async (ISender mediator) => 
        await mediator.Send(new GetLeaves()))
    .WithOpenApi()
    .WithName("GetLeaves");

app.Run();

