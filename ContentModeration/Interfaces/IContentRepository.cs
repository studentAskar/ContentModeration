using Domain.Entity;

namespace Domain.Interfaces;

public interface IContentRepository
{
    Task SaveAsync(ContentItem content);
    Task UpdateAsync(ContentItem content);
    Task<ContentItem?> GetByIdAsync(Guid id);
}

