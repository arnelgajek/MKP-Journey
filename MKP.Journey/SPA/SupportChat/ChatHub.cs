using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace MKP.Journey
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        { 
            Clients.All.broadcastMessage(name, message);
        }

        public override Task OnConnected()
        {
            var connectionId = Context.ConnectionId;
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            return base.OnReconnected();
        }
    }
}