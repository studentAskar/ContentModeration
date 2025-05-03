using Domain.Entity;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ContentRepository (ContentDbContext _db): IContentRepository
{
   

    public async Task SaveAsync(ContentItem content)
    {
        _db.ContentItems.Add(content);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateAsync(ContentItem content)
    {
        _db.ContentItems.Update(content);
        await _db.SaveChangesAsync();
    }

    public async Task<ContentItem?> GetByIdAsync(Guid id) =>
        await _db.ContentItems.FirstOrDefaultAsync(c => c.Id == id);
}
