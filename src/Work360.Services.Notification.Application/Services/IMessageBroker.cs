using MediatR;

namespace Work360.Services.Notification.Application.Services;

public interface IMessageBroker
{
    Task PublishAsync(params INotification[] events);
    Task PublishAsync(IEnumerable<INotification> events);
}