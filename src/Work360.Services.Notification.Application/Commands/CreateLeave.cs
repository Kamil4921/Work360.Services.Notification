using MediatR;

namespace Work360.Services.Notification.Application.Commands;

public class CreateLeave(Guid id, string employeeFullName, DateTime leaveStart, int leaveDuration): IRequest
{
    public Guid Id { get; } = id;
    public string EmployeeFullName { get; } = employeeFullName;
    public DateTime LeaveStart { get; } = leaveStart;
    public int LeaveDuration { get; } = leaveDuration;
}