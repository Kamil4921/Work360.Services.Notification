using MediatR;
using Work360.Services.Notification.Application;
using Work360.Services.Notification.Application.Commands;
using Work360.Services.Notification.Application.Queries;
using Work360.Services.Notification.Infrastructure;

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

app.MapGet("/notification", async (ISender mediator, Guid id) => await mediator.Send(new GetNotification(id)))
    .WithOpenApi()
    .WithName("GetNotifications");

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

