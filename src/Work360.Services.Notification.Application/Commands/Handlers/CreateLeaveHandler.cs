using MediatR;
using Work360.Services.Notification.Application.Services;
using Work360.Services.Notification.Core.Entities;
using Work360.Services.Notification.Core.Repositories;

namespace Work360.Services.Notification.Application.Commands.Handlers;

public class CreateLeaveHandler(ILeaveRepository leaveRepository, IEventMapper eventMapper, IMessageBroker messageBroker) : IRequestHandler<CreateLeave>
{
    public async Task Handle(CreateLeave request, CancellationToken cancellationToken)
    {
        var leave = Leave.CreateLeave(request.Id, request.EmployeeId, request.LeaveStart, request.LeaveDuration);
        await leaveRepository.AddLeaveAsync(leave);
        var events = eventMapper.MapAll(leave.Events);
        var publishing = messageBroker.PublishAsync(events!);

        await Task.WhenAll(publishing);
    }
}