using Work360.Services.Notification.Core.Entities;

namespace Work360.Services.Notification.Core.Repositories;

public interface ILeaveRepository
{
    Task<Leave> GetLeaveAsync(Guid id);
    Task<IEnumerable<Leave>> GetLeavesAsync();
    Task AddLeaveAsync(Leave leave);
    Task DeleteLeaveAsync(Guid id);
}