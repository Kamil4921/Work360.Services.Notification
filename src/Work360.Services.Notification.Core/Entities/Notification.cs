using Work360.Services.Notification.Core.Events;
namespace Work360.Services.Notification.Core.Entities;

public class Notification : AggregateRoot
{
    public string Text { get; set; }
    public string Title { get; set; } 
    public DateTime TimeStamp { get; set; }

    public Notification(string title, string text)
    {
        Id = Guid.NewGuid();
        Text = text;
        Title = title;
        TimeStamp = DateTime.Now;
    }
    
    public static Notification CreateNotification(string title, string text)
    {
        var notification = new Notification(title, text);
        notification.AddEvent(new NotificationCreated(notification));

        return notification;
    }
}