using MediatR;
using Work360.Services.Notification.Core;

namespace Work360.Services.Notification.Application.Services;

public interface IEventMapper
{
    INotification Map(IDomainEvent @event);
    IEnumerable<INotification?> MapAll(IEnumerable<IDomainEvent> events);
}