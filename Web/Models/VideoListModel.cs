using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Domain.Entity;
using Application.Queries.ApproveVideoCommand;
using Application.Queries.RejectVideoCommand;
using Application.Queries.GetVideosForModerationQuery;

namespace Web.Models;

public class VideoListModel : PageModel
{
    private readonly IMediator _mediator;

    public VideoListModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    public IList<Video> Videos { get; set; }

    public async Task OnGetAsync()
    {
        Videos = await _mediator.Send(new GetVideosForModerationQuery());
    }

    public async Task<IActionResult> OnPostAsync(int id, string action)
    {
        if (action == "approve")
        {
            await _mediator.Send(new ApproveVideoCommand { VideoId = id });
        }
        else if (action == "reject")
        {
            await _mediator.Send(new RejectVideoCommand { VideoId = id });
        }

        return RedirectToPage();
    }
}
