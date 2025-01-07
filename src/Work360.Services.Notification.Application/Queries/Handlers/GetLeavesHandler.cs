using MediatR;
using Work360.Services.Notification.Application.DTO;
using Work360.Services.Notification.Core.Repositories;

namespace Work360.Services.Notification.Application.Queries.Handlers;

public class GetLeavesHandler(ILeaveRepository leaveRepository) : IRequestHandler<GetLeaves, IEnumerable<LeaveDto>>
{
    public async Task<IEnumerable<LeaveDto>> Handle(GetLeaves request, CancellationToken cancellationToken)
    {
        var leaves = await leaveRepository.GetLeavesAsync();
        var leavesDto = leaves.Select(leave =>
            new LeaveDto(leave.Id, leave.EmployeeId, leave.LeaveStart, leave.LeaveDuration)).ToList();

        return leavesDto;
    }
}