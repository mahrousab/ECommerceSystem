using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace EcommerceSystem.BlazorServer.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task SendPrivateMessage(string userId, string message)
        {
            await Clients.User(userId)
                .SendAsync("ReceivePrivateMessage", message);
        }
        public async Task JoinGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task SendGroupMessage(string groupName, string message)
        {
            await Clients.Group(groupName)
                .SendAsync("ReceiveGroupMessage", message);
        }



    }
}
