using Microsoft.AspNetCore.SignalR;
namespace Infrastructure;


public class QueueHub:Hub
{
    public async Task Message(string message)
    {
        await Clients.All.SendAsync(message);
    }
}
