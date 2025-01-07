using MediatR;

namespace Work360.Services.Notification.Application.Commands;

public class CreateLeave(Guid id, Guid employeeId, DateTime leaveStart, int leaveDuration): IRequest
{
    public Guid Id { get; } = id;
    public Guid EmployeeId { get; } = employeeId;
    public DateTime LeaveStart { get; } = leaveStart;
    public int LeaveDuration { get; } = leaveDuration;
}