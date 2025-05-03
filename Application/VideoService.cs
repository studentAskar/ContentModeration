using Domain.Entity;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Application
{
    public class VideoService : IVideoService
    {
        private readonly IVideoRepository _videoRepository;
        private readonly string _storagePath;

        public VideoService(IVideoRepository videoRepository, IConfiguration configuration)
        {
            _videoRepository = videoRepository;
            _storagePath = configuration["VideoStoragePath"] ?? "wwwroot/videos";

            if (!Directory.Exists(_storagePath))
            {
                Directory.CreateDirectory(_storagePath);
            }
        }

        public async Task<Video> UploadVideoAsync(IFormFile videoFile)
        {
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(videoFile.FileName);
            var filePath = Path.Combine(_storagePath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await videoFile.CopyToAsync(stream);
            }

            var video = new Video
            {
                FileName = fileName,
                FilePath = filePath,
                Status = ContentStatus.Pending,
                UploadedAt = DateTime.UtcNow
            };

            await _videoRepository.SaveAsync(video);
            return video;
        }

        public async Task<Video> GetByIdAsync(int id)
        {
            return await _videoRepository.GetByIdAsync(id);
        }

        public async Task<List<Video>> GetAllVideosAsync()
        {
            return await _videoRepository.GetAllVideosAsync();
        }
    }
}