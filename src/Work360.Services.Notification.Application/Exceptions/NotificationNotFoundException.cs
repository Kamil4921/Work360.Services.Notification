namespace Work360.Services.Notification.Application.Exceptions;

public class NotificationNotFoundException(Guid notificationId) : ApplicationException($"Can't find notification with id: {notificationId}.")
{
    public override string Code => "notification_not_found";
}