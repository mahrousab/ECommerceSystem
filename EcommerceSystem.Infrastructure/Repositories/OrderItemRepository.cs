using Ecommerce.Application.IRepository;
using EcommerceSystem.Domain.Models;
using EcommerceSystem.Infrastructure.Data;

namespace Ecommerce.Application.Repository;

public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository, IGenericRepository<OrderItem>
{
	public OrderItemRepository(ECommerceSystemDbContext context)
		: base(context)
	{
	}
}
