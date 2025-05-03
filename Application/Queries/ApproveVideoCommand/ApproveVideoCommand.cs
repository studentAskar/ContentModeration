using MediatR;

namespace Application.Queries.ApproveVideoCommand;

public class ApproveVideoCommand : IRequest
{
    public int VideoId { get; set; }
}
