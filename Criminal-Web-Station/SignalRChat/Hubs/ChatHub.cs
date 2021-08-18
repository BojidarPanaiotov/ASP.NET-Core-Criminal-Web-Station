namespace SignalRChat.Hubs
{
    using Microsoft.AspNetCore.SignalR;
    using System.Threading.Tasks;
    public class ChatHub : Hub
    {

        public async Task SendMessage(string user, string message,string id)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message,id);
        }
    }
}