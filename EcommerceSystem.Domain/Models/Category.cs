using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcommerceSystem.Domain.Models;

public class Category
{
    [Required]
    public int Id { get; set; }

	public string Name { get; set; }

	public ICollection<Product> Products { get; set; }
}
