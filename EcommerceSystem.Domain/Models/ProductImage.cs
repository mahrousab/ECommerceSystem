using System.ComponentModel.DataAnnotations;

namespace EcommerceSystem.Domain.Models;

public class ProductImage
{
    [Required]
    public int Id { get; set; }

	public string ImageUrl { get; set; }

	public int ProductId { get; set; }

	public Product Product { get; set; }
}
