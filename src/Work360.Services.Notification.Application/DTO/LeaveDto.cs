using Work360.Services.Notification.Core.Entities;

namespace Work360.Services.Notification.Application.DTO;

public record LeaveDto
{
    public Guid LeaveId { get; set; }
    public Guid EmployeeId { get; set; }
    public DateTime LeaveStart { get; set; }
    public int LeaveDuration { get; set; }
    
    public LeaveDto(Guid leaveId, Guid employeeId, DateTime leaveStart, int leaveDuration)
    {
        LeaveId = leaveId;
        EmployeeId = employeeId;
        LeaveStart = leaveStart;
        LeaveDuration = leaveDuration;
    }
}