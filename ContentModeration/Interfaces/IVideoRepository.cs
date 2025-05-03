using Domain.Entity;

namespace Domain.Interfaces;

public interface IVideoRepository
{
    Task<Video> GetByIdAsync(int id);
    Task<List<Video>> GetVideosByStatusAsync(ContentStatus status);
    Task<List<Video>> GetAllVideosAsync();
    Task SaveAsync(Video video);
}
