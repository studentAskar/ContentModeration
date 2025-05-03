using Application.Queries.ApproveVideoCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Views.TextContent;

public class ApproveModel : PageModel
{
    private readonly IMediator _mediator;

    public ApproveModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    [BindProperty]
    public ApproveVideoCommand Command { get; set; } = new();

    public string? ResultMessage { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        await _mediator.Send(Command);
        ResultMessage = "Video approved.";
        return Page();
    }
}
