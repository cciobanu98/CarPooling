using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace CarPooling.BussinesLogic.Hubs
{
    public class NotificationHub : Hub
    {
        private readonly static ConnectionMapping<string> _connections =
            new ConnectionMapping<string>();

        public override Task OnConnectedAsync()
        {
            string name = Context.User.Identity.Name;
            if (name != null)
                 _connections.Add(name, Context.ConnectionId);

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception e)
        {
            string name = Context.User.Identity.Name;
            if (name != null)
                _connections.Remove(name, Context.ConnectionId);

            return base.OnDisconnectedAsync(e);
        }
    }
}
