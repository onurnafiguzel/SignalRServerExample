using Microsoft.AspNetCore.SignalR;

namespace SignalRServerExample.Hubs
{
    public class MessageHub : Hub
    {
        //public async Task SendMessageAsync(string message, IEnumerable<string> connectionIds)
        public async Task SendMessageAsync(string message, string groupName)
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
            // await Clients.Others.SendAsync("receiveMessage", message);
            #endregion

            #region Hub Clients Metotları
            #region AllExcept
            // Belirtilen clientlar gariç servera bağlı oln tüm clientlara bildiride bulunur.
            //await Clients.AllExcept(connectionIds).SendAsync("receiveMessage", message);
            #endregion
            #region Client
            // Belli bir clienta bildiri.
            //await Clients.Client(connectionIds.First()).SendAsync("receiveMessage", message);
            #endregion
            #region Clients
            // Servera bağlı olan clientlara bildirir. AllExcept'in tersidir.
            //await Clients.Clients(connectionIds).SendAsync("receiveMessage", message);
            #endregion
            #region Group
            // Belirtilen gruptaki tüm clientlara bildiride bulunur.
            // Önce gruplar oluşturulmalı ve ardından clientlar gruplara subscribe olmalı.
            await Clients.Group(groupName).SendAsync("receiveMessage", message);
            #endregion
            #endregion
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("getConnectionId", Context.ConnectionId);
        }

        public async Task addGroup(string connectionId, string groupName)
        {
            await Groups.AddToGroupAsync(connectionId, groupName);
        }
    }
}
