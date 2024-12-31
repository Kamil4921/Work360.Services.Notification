using Work360.Services.Notification.Core.Entities;

namespace Work360.Services.Notification.Core.Events;

public class LeaveCreated(Leave leave) : IDomainEvent
{
    public Leave Leave { get; } = leave;
}