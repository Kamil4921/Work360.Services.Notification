using Newtonsoft.Json;

namespace Work360.Services.Notification.Core.Entities;

public class AggregateRoot
{
    [JsonProperty("id")]
    public Guid Id { get; set; }
    
    [JsonIgnore]
    private readonly List<IDomainEvent> _events = new();
    
    [JsonIgnore]
    public IEnumerable<IDomainEvent> Events => _events;
    public int Version { get; set; }
    protected void AddEvent(IDomainEvent @event)
        => _events.Add(@event);

    public void ClearEvents() => _events.Clear();
}