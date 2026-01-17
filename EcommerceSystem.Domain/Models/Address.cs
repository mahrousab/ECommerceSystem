using Ecommerce.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace EcommerceSystem.Domain.Models;

public class Address
{
	[Required]
	public int Id { get; set; }

	public string Country { get; set; }

	public string City { get; set; }

	public string Street { get; set; }

	public string PostalCode { get; set; }

	public int UserId { get; set; }

	public User User { get; set; }
}
