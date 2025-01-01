namespace Work360.Services.Notification.Application.Exceptions;

public class LeaveNotFoundException(Guid leaveId) : ApplicationException($"Can't find leave with id: {leaveId}.")
{
    public override string Code => "leave_not_found";
}