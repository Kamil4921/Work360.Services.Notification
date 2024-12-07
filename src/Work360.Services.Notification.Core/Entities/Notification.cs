using Work360.Services.Notification.Core.Events;

namespace Work360.Services.Notification.Core.Entities;

public class Notification : AggregateRoot
{
    public string Email { get; set; }
    public string Text { get; set; }
    public string Title { get; set; } 
    public DateTime TimeStamp { get; set; }

    private Notification(string email, string title, string text)
    {
        Email = email;
        Text = text;
        Title = title;
        TimeStamp = DateTime.Now;
    }
    
    public static Notification CreateNotification(string email, string title, string text)
    {
        var notification = new Notification(email, title, text);
        notification.AddEvent(new NotificationCreated(notification));

        return notification;
    }
}