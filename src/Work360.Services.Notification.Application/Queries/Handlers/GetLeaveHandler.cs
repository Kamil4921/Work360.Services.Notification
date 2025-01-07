using MediatR;
using Work360.Services.Notification.Application.DTO;
using Work360.Services.Notification.Application.Exceptions;
using Work360.Services.Notification.Core.Repositories;

namespace Work360.Services.Notification.Application.Queries.Handlers;

public class GetLeaveHandler(ILeaveRepository leaveRepository) : IRequestHandler<GetLeave, LeaveDto>
{
    public async Task<LeaveDto> Handle(GetLeave request, CancellationToken cancellationToken)
    {
        var leave = await leaveRepository.GetLeaveAsync(request.LeaveId);
        if (leave is null)
        {
            throw new LeaveNotFoundException(request.LeaveId);
        }

        var leaveDto = new LeaveDto(leave.Id, leave.EmployeeId, leave.LeaveStart, leave.LeaveDuration);

        return leaveDto;
    }
}