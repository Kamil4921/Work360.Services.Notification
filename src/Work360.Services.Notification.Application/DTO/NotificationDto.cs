namespace Work360.Services.Notification.Application.DTO;

public record NotificationDto(Core.Entities.Notification notification)
{
    public string Text { get; } = notification.Text;
    public string Title { get; } = notification.Title;
}