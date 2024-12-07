namespace Work360.Services.Notification.Core.Entities;

public class AggregateRoot
{
    public Guid Id { get; set; }
    private readonly List<IDomainEvent> _events = new();
    public IEnumerable<IDomainEvent> Events => _events;
    public int Version { get; set; }
    protected void AddEvent(IDomainEvent @event)
        => _events.Add(@event);

    public void ClearEvents() => _events.Clear();
}