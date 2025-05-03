using MediatR;

namespace Application.Queries.RejectVideoCommand;

public class RejectVideoCommand : IRequest
{
    public int VideoId { get; set; }
}
