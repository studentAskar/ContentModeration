using Domain.Entity;
using Domain.Interfaces;
using System.Threading.Channels;

namespace Infrastructure;

public class InMemoryQueueService : IQueueService
{
    private readonly Channel<ContentItem> _channel = Channel.CreateUnbounded<ContentItem>();

    public async Task EnqueueAsync(ContentItem item) =>
        await _channel.Writer.WriteAsync(item);

    public IAsyncEnumerable<ContentItem> ReadAllAsync(CancellationToken ct) =>
        _channel.Reader.ReadAllAsync(ct);
}
