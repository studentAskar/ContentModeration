using Application;
using Domain.Entity;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class VideoController : Controller
    {
        private readonly IVideoService _videoService;

        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile videoFile)
        {
            try
            {
                if (videoFile == null || videoFile.Length == 0)
                {
                    ModelState.AddModelError("", "Please select a file to upload.");
                    return View();
                }

                var video = await _videoService.UploadVideoAsync(videoFile);
                return RedirectToAction("Details", new { id = video.Id });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error uploading video: {ex.Message}");
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var video = await _videoService.GetByIdAsync(id);
            if (video == null)
            {
                return NotFound();
            }
            return View(video);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var videos = await _videoService.GetAllVideosAsync();
            return View(videos);
        }
    }
}