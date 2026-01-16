using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcommerceSystem.Domain.Models;

public class User
{
    [Required]
    public int Id { get; set; }

	public string Name { get; set; }

	public string Email { get; set; }

	public string PasswordHash { get; set; }

	public string Phone { get; set; }

	public DateTime CreatedAt { get; set; }

	public ICollection<Order> Orders { get; set; }

	public ICollection<Address> Addresses { get; set; }
}
