using Ecommerce.Application.IRepository;
using EcommerceSystem.Domain.Models;
using EcommerceSystem.Infrastructure.Data;

namespace Ecommerce.Application.Repository;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository, IGenericRepository<Category>
{
	public CategoryRepository(ECommerceSystemDbContext eCommerceDbContext)
		: base(eCommerceDbContext)
	{
	}
}
