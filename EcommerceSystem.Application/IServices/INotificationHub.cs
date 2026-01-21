using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceSystem.Application.IServices
{
    public interface INotificationHub
    {
        Task SendToUserAsync(Guid userId, string message);

    }
}
