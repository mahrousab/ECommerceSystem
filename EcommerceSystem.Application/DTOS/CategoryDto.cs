using System.ComponentModel.DataAnnotations;

namespace EcommerceSystem.Application.DTOS;

public class CategoryDto
{
	[Required]
	public string Name { get; set; }
}
