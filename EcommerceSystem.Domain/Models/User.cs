using EcommerceSystem.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Ecommerce.Domain.Models;

public class User : IdentityUser<Guid>
{
    public ICollection<RefreshToken> RefreshTokens { get; set; }
        = new List<RefreshToken>();


    public int Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string PasswordHash { get; set; }

    public string Phone { get; set; }

    public DateTime CreatedAt { get; set; }

    public ICollection<Order> Orders { get; set; }

    public ICollection<Address> Addresses { get; set; }
}