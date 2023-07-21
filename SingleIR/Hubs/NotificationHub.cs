using Microsoft.AspNetCore.SignalR;
using SingleIR.Models;

namespace SingleIR.Hubs
{
    public class NotificationHub : Hub
    {
        //public async Task SendMessages(string message)
        //{
        //    await Clients.All.SendAsync("ReceivedMessage", message);
        //}

        public override Task OnConnectedAsync()
        {
            ConnectedUser.UserId.Add(Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            ConnectedUser.UserId.Remove(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
