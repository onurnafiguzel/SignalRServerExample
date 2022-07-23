using Microsoft.AspNetCore.SignalR;

namespace SignalRServerExample.Hubs
{
    public class MessageHub : Hub
    {
        public async Task SendMessageAsync(string message)
        {
            #region Caller
            // Sadece server'a bildirim gönderen client ile iletişim kurar.
            //await Clients.Caller.SendAsync("receiveMessage", message);
            #endregion

            #region All
            // Server'a bağlı tüm clientlar ile iletişim kurar.
            //await Clients.All.SendAsync("receiveMessage", message);
            #endregion

            #region Other
            // Sadece servera bildirim gönderen client dışında Server'a bağlı olan tüm clientlara mesaj gönderir.
            await Clients.Others.SendAsync("receiveMessage", message);
            #endregion

        }
    }
}
