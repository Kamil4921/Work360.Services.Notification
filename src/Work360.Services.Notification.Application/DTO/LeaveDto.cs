namespace Work360.Services.Notification.Application.DTO;

public class LeaveDto
{
    public Guid LeaveId { get; set; }
    public string EmployeeFullName { get; set; }
    public DateTime LeaveStart { get; set; }
    public int LeaveDuration { get; set; }

    public LeaveDto()
    {
    }

    public LeaveDto(Guid leaveId, string employeeFullName, DateTime leaveStart, int leaveDuration)
    {
        LeaveId = leaveId;
        EmployeeFullName = employeeFullName;
        LeaveStart = leaveStart;
        LeaveDuration = leaveDuration;
    }
}