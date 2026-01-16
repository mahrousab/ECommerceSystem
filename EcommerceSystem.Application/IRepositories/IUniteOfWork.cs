using System;
using System.Threading.Tasks;

namespace Ecommerce.Application.IRepository;

public interface IUniteOfWork : IDisposable
{
	IUserRepository Users { get; }

	IProductRepository Products { get; }

	IPaymentRepository Payments { get; }

	IAddressRepository Addresses { get; }

	ICategoryRepository Category { get; }

	IOrderRepository Order { get; }

	IOrderItemRepository OrderItem { get; }

	IProductImageRepository ProductImage { get; }

	Task<int> CompleteAsync();
}
