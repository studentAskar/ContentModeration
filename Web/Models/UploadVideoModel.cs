using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Domain.Interfaces;

namespace Web.Models
{
    public class UploadVideoModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IVideoService _videoService;

        public UploadVideoModel(IMediator mediator, IVideoService videoService)
        {
            _mediator = mediator;
            _videoService = videoService;
        }

        [BindProperty]
        public IFormFile VideoFile { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (VideoFile == null || VideoFile.Length == 0)
            {
                ModelState.AddModelError("VideoFile", "Пожалуйста, выберите файл.");
                return Page();
            }

            // Загрузим видео и создадим запись в базе данных
            var video = await _videoService.UploadVideoAsync(VideoFile);

            // Перенаправим на страницу с видео
            return RedirectToPage("/VideoList");
        }
    }

}
