using Domain.Entity;
using MediatR;

namespace Application.Queries.GetVideosForModerationQuery;

public record GetVideosForModerationQuery : IRequest<List<Video>>;
