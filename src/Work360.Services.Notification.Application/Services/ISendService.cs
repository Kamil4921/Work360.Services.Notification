namespace Work360.Services.Notification.Application.Services;

public interface ISendService
{
    Task SendEmail(Core.Entities.Notification notification);
}