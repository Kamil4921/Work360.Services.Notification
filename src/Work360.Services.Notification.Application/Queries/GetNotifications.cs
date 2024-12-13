using MediatR;
using Work360.Services.Notification.Application.DTO;

namespace Work360.Services.Notification.Application.Queries;

[Contract]
public class GetNotifications : IRequest<IEnumerable<NotificationDto>>
{
}