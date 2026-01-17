using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcommerceSystem.Domain.Models;

public class Order
{
    [Required]
    public int Id { get; set; }

	public string Status { get; set; }

	public decimal TotalPrice { get; set; }

	public DateTime CreatedAt { get; set; }

	public int UserId { get; set; }

	public User User { get; set; }

	public ICollection<OrderItem> OrderItems { get; set; }

	public Payment Payment { get; set; }
}
