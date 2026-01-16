using Ecommerce.Application.IRepository;
using EcommerceSystem.Domain.Models;
using EcommerceSystem.Infrastructure.Data;

namespace Ecommerce.Application.Repository;

public class ProductImageReposioty : GenericRepository<ProductImage>, IProductImageRepository, IGenericRepository<ProductImage>
{
	public ProductImageReposioty(ECommerceSystemDbContext eCommerceDbContext)
		: base(eCommerceDbContext)
	{
	}
}
