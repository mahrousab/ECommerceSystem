using System;
using System.ComponentModel.DataAnnotations;

namespace EcommerceSystem.Domain.Models;

public class Payment
{
    [Required]
    public int Id { get; set; }

	public string PaymentMethod { get; set; }

	public string PaymentStatus { get; set; }

	public DateTime PaidAt { get; set; }

	public int OrderId { get; set; }

	public Order Order { get; set; }
}
