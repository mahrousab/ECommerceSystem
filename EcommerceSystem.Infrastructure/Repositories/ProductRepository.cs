using Ecommerce.Application.IRepository;
using EcommerceSystem.Domain.Models;
using EcommerceSystem.Infrastructure.Data;

namespace Ecommerce.Application.Repository;

public class ProductRepository : GenericRepository<Product>, IProductRepository, IGenericRepository<Product>
{
	public ProductRepository(ECommerceSystemDbContext eCommerceDbContext)
		: base(eCommerceDbContext)
	{
	}
}
