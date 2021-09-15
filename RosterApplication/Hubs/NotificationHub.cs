using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace RosterApplication.Hubs
{
    public class NotificationHub : Hub
    {

        public async Task SendNotification(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
        
    }
}