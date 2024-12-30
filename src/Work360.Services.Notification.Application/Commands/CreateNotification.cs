using MediatR;

namespace Work360.Services.Notification.Application.Commands;

[Contract]
public class CreateNotification(string text, string title) : IRequest<Guid>
{
    public string Text { get; } = text;
    public string Title { get; } = title;
}