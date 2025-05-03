using Domain.Entity;
using Domain.Interfaces;
using MediatR;

namespace Application.Queries.GetVideosForModerationQuery;

public class GetVideosForModerationQueryHandler(IVideoRepository _videoRepository) : IRequestHandler<GetVideosForModerationQuery, List<Video>>
{
     

    public async Task<List<Video>> Handle(GetVideosForModerationQuery request, CancellationToken cancellationToken)
    {
        // Получаем все видео со статусом Pending (на модерации)
        return await _videoRepository.GetVideosByStatusAsync(ContentStatus.Pending);
    }
}
