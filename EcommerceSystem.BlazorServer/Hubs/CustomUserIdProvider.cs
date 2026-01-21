using Microsoft.AspNetCore.SignalR;

namespace EcommerceSystem.BlazorServer.Hubs
{
    public class CustomUserIdProvider : IUserIdProvider
    {
        public string GetUserId(HubConnectionContext connection)
        => connection.ConnectionId;
    }
}
