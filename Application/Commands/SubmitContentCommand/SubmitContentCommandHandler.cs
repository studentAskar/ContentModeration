using Domain.Entity;
using Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Commands.SubmitContentCommand;
public class SubmitContentCommandHandler(
    IContentRepository _repo,
    IQueueService _queue,
    IMemoryCache _cache // добавлен кэш
) : IRequestHandler<SubmitContentCommand, Guid>
{
    private const string CacheKey = "Cache";
    public async Task<Guid> Handle(SubmitContentCommand request, CancellationToken cancellationToken)
    {
        var content = new ContentItem
        {
            Id = Guid.NewGuid(),
            Type = request.Type,
            PathOrText = request.PathOrText,
            Status = ContentStatus.Pending,
            UploadedAt = DateTime.UtcNow
        };

        try
        {
            await _repo.SaveAsync(content); 
        }
        catch (Exception ex)
        {
            

            
            _cache.Set(CacheKey,content);
        }

        await _queue.EnqueueAsync(content); 
        return content.Id;
    }
}

