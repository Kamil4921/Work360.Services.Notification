using Work360.Services.Notification.Core.Events;

namespace Work360.Services.Notification.Core.Entities;

public class Leave : AggregateRoot
{
    public string EmployeeFullName { get; }
    public DateTime LeaveStart { get; }
    public int LeaveDuration { get; }

    private Leave(Guid id, string employeeFullName, DateTime leaveStart, int leaveDuration)
    {
        Id = id;
        EmployeeFullName = employeeFullName;
        LeaveStart = leaveStart;
        LeaveDuration = leaveDuration;
    }

    public static Leave CreateLeave(Guid id, string employeeFullName, DateTime leaveStart, int leaveDuration)
    {
        var leave = new Leave(id, employeeFullName, leaveStart, leaveDuration);
        leave.AddEvent(new LeaveCreated(leave));

        return leave;
    }
}