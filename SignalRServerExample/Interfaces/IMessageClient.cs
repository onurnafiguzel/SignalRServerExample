namespace SignalRServerExample.Interfaces
{
    public interface IMessageClient
    {
        Task Clients(List<string> clients);
        Task UserJoined(string connectionId);
        Task UserLeft(string connectionId);
    }
}
