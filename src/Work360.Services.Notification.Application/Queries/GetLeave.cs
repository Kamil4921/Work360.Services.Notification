using MediatR;
using Work360.Services.Notification.Application.DTO;

namespace Work360.Services.Notification.Application.Queries;

public class GetLeave(Guid leaveId) : IRequest<LeaveDto>
{
    public Guid LeaveId { get; } = leaveId;
}