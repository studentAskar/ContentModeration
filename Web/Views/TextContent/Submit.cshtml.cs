using Application.Commands.SubmitContentCommand;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Views.TextContent;

public class SubmitModel : PageModel
{
    private readonly IMediator _mediator;

    public SubmitModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    [BindProperty]
    public SubmitContentCommand Command { get; set; } = new("", "");

    public string? ResultMessage { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        var id = await _mediator.Send(Command);
        ResultMessage = $"Content submitted with ID: {id}";
        return Page();
    }
}
