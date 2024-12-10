using Work360.Services.Notification.Core.Events;
using Work360.Services.Notification.Core.Exceptions;

namespace Work360.Services.Notification.Core.Entities;

public class Notification : AggregateRoot
{
    public string Email { get; set; }
    public string Text { get; set; }
    public string Title { get; set; } 
    public DateTime TimeStamp { get; set; }

    private Notification(string email, string title, string text)
    {
        Id = Guid.NewGuid();
        Email = email;
        Text = text;
        Title = title;
        TimeStamp = DateTime.Now;
    }
    
    public static Notification CreateNotification(string email, string title, string text)
    {
        CheckEmail(email);
        var notification = new Notification(email, title, text);
        notification.AddEvent(new NotificationCreated(notification));

        return notification;
    }

    private static void CheckEmail(string email)
    {
        if (!email.Contains('@'))
        {
            throw new InvalidEmailException(email);
        }
    }
}