using Ecommerce.Application.IRepository;
using EcommerceSystem.Domain.Models;
using EcommerceSystem.Infrastructure.Data;

namespace Ecommerce.Application.Repository;

public class OrderRepository : GenericRepository<Order>, IOrderRepository, IGenericRepository<Order>
{
	public OrderRepository(ECommerceSystemDbContext eCommerceDbContext)
		: base(eCommerceDbContext)
	{
	}
}
