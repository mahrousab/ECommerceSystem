using System.ComponentModel.DataAnnotations;

namespace EcommerceSystem.Application.DTOS;

public class ProductDto
{
	[Required]
	[MaxLength(100)]
	public string Name { get; set; }

	[Required]
	[MaxLength(200)]
	public string Description { get; set; }

	[Required]
	[MaxLength(100)]
	public decimal Price { get; set; }
}
