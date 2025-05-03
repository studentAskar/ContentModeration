using Application.Commands.SubmitContentCommand;
using Application.Queries.ApproveVideoCommand;
using Application.Queries.RejectVideoCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ContentModeration.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContentController(IMediator mediator) : ControllerBase
{
    [HttpPost("submit")]
    public async Task<IActionResult> Submit(SubmitContentCommand command)
    {
        var id = await mediator.Send(command);
        return Ok(new { Id = id });
    }

    [HttpPost("approve")]
    public async Task<IActionResult> Approve(ApproveVideoCommand command)
    {
        await mediator.Send(command);
        return Ok(new { Message = "Video approved" });
    }

    [HttpPost("reject")]
    public async Task<IActionResult> Reject(RejectVideoCommand command)
    {
        await mediator.Send(command);
        return Ok(new { Message = "Video rejected" });
    }
}
