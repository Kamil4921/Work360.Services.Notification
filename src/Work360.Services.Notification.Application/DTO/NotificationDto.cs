namespace Work360.Services.Notification.Application.DTO;

public record NotificationDto(Core.Entities.Notification notification)
{
    public string Email { get; } = notification.Email;
    public string Text { get; } = notification.Text;
    public string Title { get; } = notification.Title;
}