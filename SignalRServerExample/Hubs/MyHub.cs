using Microsoft.AspNetCore.SignalR;

namespace SignalRServerExample.Hubs
{
    public class MyHub : Hub
    {
        public async Task SendMessageAsync(string message)
        {
            await Clients.All.SendAsync("receiveMessage", message); //Client'ta receiveMessage isimli fonksiyonu tetikle, parametre olarak message'ı al.
        }
    }
}
