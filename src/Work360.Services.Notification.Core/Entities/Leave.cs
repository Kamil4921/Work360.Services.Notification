using Work360.Services.Notification.Core.Events;

namespace Work360.Services.Notification.Core.Entities;

public class Leave : AggregateRoot
{
    public Guid EmployeeId { get; }
    public DateTime LeaveStart { get; }
    public int LeaveDuration { get; }

    private Leave(Guid id, Guid employeeId, DateTime leaveStart, int leaveDuration)
    {
        Id = id;
        EmployeeId = employeeId;
        LeaveStart = leaveStart;
        LeaveDuration = leaveDuration;
    }

    public static Leave CreateLeave(Guid id, Guid employeeId, DateTime leaveStart, int leaveDuration)
    {
        var leave = new Leave(id, employeeId, leaveStart, leaveDuration);
        leave.AddEvent(new LeaveCreated(leave));

        return leave;
    }
}