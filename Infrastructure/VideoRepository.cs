using Domain;
using Domain.Entity;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class VideoRepository(QueueDbContext _dbContext) : IVideoRepository
{
    

    public async Task<Video> GetByIdAsync(int id)
    {
        return await _dbContext.Videos.FindAsync(id);
    }

    public async Task<List<Video>> GetVideosByStatusAsync(ContentStatus status)
    {
        return await _dbContext.Videos.Where(v => v.Status == (int)status).ToListAsync();
    }
    public async Task<List<Video>> GetAllVideosAsync()
    {
        return await _dbContext.Videos.ToListAsync();
    }

    public async Task SaveAsync(Video video)
    {
        if (video.Id == 0)
        {
            _dbContext.Videos.Add(video);
        }
        else
        {
            _dbContext.Videos.Update(video);
        }

        await _dbContext.SaveChangesAsync();
    }
}
