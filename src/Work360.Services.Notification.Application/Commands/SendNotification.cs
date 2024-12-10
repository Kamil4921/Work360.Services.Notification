using MediatR;

namespace Work360.Services.Notification.Application.Commands;

public class SendNotification(Core.Entities.Notification notification) : IRequest<Guid>
{
    public Core.Entities.Notification Notification { get; } = notification;
}