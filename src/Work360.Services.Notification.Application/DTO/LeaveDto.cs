using Work360.Services.Notification.Core.Entities;

namespace Work360.Services.Notification.Application.DTO;

public record LeaveDto
{
    public Guid LeaveId { get; set; }
    public string EmployeeFullName { get; set; }
    public DateTime LeaveStart { get; set; }
    public int LeaveDuration { get; set; }
    
    public LeaveDto(Leave leave)
    {
        LeaveId = leave.Id;
        EmployeeFullName = leave.EmployeeFullName;
        LeaveStart = leave.LeaveStart;
        LeaveDuration = leave.LeaveDuration;
    }
}