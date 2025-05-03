using Domain.Entity;
using Microsoft.AspNetCore.Http;

namespace Domain.Interfaces;
public interface IVideoService
{
    Task<Video> UploadVideoAsync(IFormFile videoFile);
    Task<Video> GetByIdAsync(int id);
    Task<List<Video>> GetAllVideosAsync();
}
