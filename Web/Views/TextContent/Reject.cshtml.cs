using Application.Queries.RejectVideoCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Views.TextContent;

public class RejectModel : PageModel
{
    private readonly IMediator _mediator;

    public RejectModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    [BindProperty]
    public RejectVideoCommand Command { get; set; } = new();

    public string? ResultMessage { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        await _mediator.Send(Command);
        ResultMessage = "Video rejected.";
        return Page();
    }
}
