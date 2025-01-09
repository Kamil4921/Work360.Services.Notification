namespace Work360.Services.Notification.Application.DTO;

public record LeaveDto(Guid LeaveId, Guid EmployeeId, DateTime LeaveStart, int LeaveDuration)
{
    public Guid LeaveId { get; set; } = LeaveId;
    public Guid EmployeeId { get; set; } = EmployeeId;
    public DateTime LeaveStart { get; set; } = LeaveStart;
    public int LeaveDuration { get; set; } = LeaveDuration;
}