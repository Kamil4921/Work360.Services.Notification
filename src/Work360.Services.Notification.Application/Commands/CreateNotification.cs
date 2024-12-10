using MediatR;

namespace Work360.Services.Notification.Application.Commands;

[Contract]
public class CreateNotification(string email, string text, string title) : IRequest<Guid>
{
    public string Email { get; } = email;
    public string Text { get; } = text;
    public string Title { get; } = title;
}