using Domain.Entity;
using Domain.Interfaces;
using MediatR;

namespace Application.Queries.ApproveVideoCommand;

public class ApproveVideoCommandHandler(IVideoRepository _videoRepository) : IRequestHandler<ApproveVideoCommand>
{
    

    public async Task Handle(ApproveVideoCommand request, CancellationToken cancellationToken)
    {
        var video = await _videoRepository.GetByIdAsync(request.VideoId);
        if (video != null)
        {
            video.Status = (int)ContentStatus.Approved;
            await _videoRepository.SaveAsync(video);
        }

        return ;
    }
}


