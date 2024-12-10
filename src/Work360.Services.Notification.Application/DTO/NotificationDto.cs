namespace Work360.Services.Notification.Application.DTO;

public record NotificationDto(string Email, string Text, string Title)
{
    public string Email { get; } = Email;
    public string Text { get; } = Text;
    public string Title { get; } = Title;
}