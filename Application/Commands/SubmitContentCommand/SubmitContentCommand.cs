using MediatR;

namespace Application.Commands.SubmitContentCommand;

public record SubmitContentCommand(string Type, string PathOrText) : IRequest<Guid>;
