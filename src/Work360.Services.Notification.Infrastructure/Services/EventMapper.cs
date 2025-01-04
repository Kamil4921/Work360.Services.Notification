using MediatR;
using Work360.Services.Notification.Application.Services;
using Work360.Services.Notification.Core;
using Work360.Services.Notification.Core.Events;

namespace Work360.Services.Notification.Infrastructure.Services;

public class EventMapper : IEventMapper
{
    public INotification? Map(IDomainEvent @event)
    {
        return @event switch
        {
            LeaveCreated e => new Application.Events.LeaveCreated(e.Leave.Id, e.Leave.EmployeeFullName, e.Leave.LeaveStart, e.Leave.LeaveDuration),
            NotificationCreated e => new Application.Events.NotificationCreated(e.Notification.Id),
            _ => null
        };
    }

    public IEnumerable<INotification?> MapAll(IEnumerable<IDomainEvent> events)
    => events.Select(Map);
}