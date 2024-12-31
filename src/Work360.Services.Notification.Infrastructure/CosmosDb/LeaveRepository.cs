using Work360.Services.Notification.Core.Entities;
using Work360.Services.Notification.Core.Repositories;

namespace Work360.Services.Notification.Infrastructure.CosmosDb;

public class LeaveRepository(CosmosDbContext context) : ILeaveRepository
{
    public Task<Leave> GetLeaveAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Leave>> GetLeaveAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddLeaveAsync(Leave leave)
    {
        await context.LeavesContainer.CreateItemAsync(leave);
    }

    public Task DeleteLeaveAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}