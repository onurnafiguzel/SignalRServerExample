using Microsoft.AspNetCore.SignalR;

namespace SignalRServerExample.Hubs
{
    public class MyHub : Hub
    {

        static List<string> clients = new();

        public override async Task OnConnectedAsync()
        {
            clients.Add(Context.ConnectionId);
            await Clients.All.SendAsync("clients", clients);
            await Clients.All.SendAsync("userJoined", Context.ConnectionId);
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clients.Remove(Context.ConnectionId);
            await Clients.All.SendAsync("clients", clients);
            await Clients.All.SendAsync("userLeft", Context.ConnectionId);
        }
    }
}
