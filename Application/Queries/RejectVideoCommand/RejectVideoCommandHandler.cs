using Domain.Entity;
using Domain.Interfaces;
using MediatR;

namespace Application.Queries.RejectVideoCommand;

public class RejectVideoCommandHandler(IVideoRepository _videoRepository) : IRequestHandler<RejectVideoCommand>
{
    

    public async Task Handle(RejectVideoCommand request, CancellationToken cancellationToken)
    {
        var video = await _videoRepository.GetByIdAsync(request.VideoId);
        if (video != null)
        {
            video.Status = (int)ContentStatus.Rejected;
            await _videoRepository.SaveAsync(video);
        }

        return;
    }
}
