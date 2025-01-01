using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Work360.Services.Notification.Core.Entities;
using Work360.Services.Notification.Core.Repositories;

namespace Work360.Services.Notification.Infrastructure.CosmosDb;

public class LeaveRepository(CosmosDbContext context) : ILeaveRepository
{
    public async Task<Leave> GetLeaveAsync(Guid id)
    {
        return await context.LeavesContainer.ReadItemAsync<Leave>(id.ToString(), new PartitionKey(id.ToString()));
    }

    public async Task<IEnumerable<Leave>> GetLeavesAsync()
    {
        var iterator = context.LeavesContainer.GetItemLinqQueryable<Leave>().ToFeedIterator();
        var leave = new List<Leave>();

        while (iterator.HasMoreResults)
        {
            var response = await iterator.ReadNextAsync();
            leave.AddRange(response);
        }

        return leave;
    }

    public async Task AddLeaveAsync(Leave leave)
    {
        await context.LeavesContainer.CreateItemAsync(leave);
    }

    public Task DeleteLeaveAsync(Guid id)
    {
        return context.LeavesContainer.DeleteItemAsync<Leave>(id.ToString(),
            new PartitionKey(id.ToString()));
    }
}