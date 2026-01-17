using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Ecommerce.Domain.Models;
namespace EcommerceSystem.Domain.Models
{
    public class RefreshToken
    {
        public readonly bool IsActive;

        public Guid Id { get; set; }
        public string Token { get; set; } = null!;
        public DateTime ExpiresOn { get; set; }
        public bool IsRevoked { get; set; }

        public Guid UserId { get; set; }
        public User user { get; set; } = null!;
    }
}
