using MediatR;
using Work360.Services.Notification.Application.Services;
using Work360.Services.Notification.Core.Repositories;

namespace Work360.Services.Notification.Application.Commands.Handlers;

public class CreateNotificationHandler(INotificationRepository notificationRepository, IEventMapper eventMapper, IMessageBroker messageBroker) : IRequestHandler<CreateNotification, Guid>
{
    public async Task<Guid> Handle(CreateNotification request, CancellationToken cancellationToken)
    {
        var notification = Core.Entities.Notification.CreateNotification(request.Email, request.Title, request.Text);
        var adding = notificationRepository.AddNotification(notification);
        var events = eventMapper.MapAll(notification.Events);
        var publishing = messageBroker.PublishAsync(events!);

        await Task.WhenAll(adding, publishing);

        return notification.Id;
    }
}