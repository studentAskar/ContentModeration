using Domain.Entity;

namespace Domain.Interfaces;

public interface IQueueService
{
    Task EnqueueAsync(ContentItem item);
    IAsyncEnumerable<ContentItem> ReadAllAsync(CancellationToken ct);
}