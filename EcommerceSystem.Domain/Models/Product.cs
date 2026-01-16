using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcommerceSystem.Domain.Models;

public class Product
{
    [Required]
    public int Id { get; set; }

	public string Name { get; set; }

	public string Description { get; set; }

	public decimal Price { get; set; }

	public int Stock { get; set; }

	public int CategoryId { get; set; }

	public Category Category { get; set; }

	public ICollection<ProductImage> Images { get; set; }

	public ICollection<OrderItem> OrderItems { get; set; }
}
