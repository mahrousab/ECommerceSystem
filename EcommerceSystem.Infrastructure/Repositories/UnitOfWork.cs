using System;
using System.Threading.Tasks;
using Ecommerce.Application.IRepository;
using EcommerceSystem.Infrastructure.Data;

namespace Ecommerce.Infrastructure.Repositories;

public class UnitOfWork : IUniteOfWork, IDisposable
{
	private readonly ECommerceSystemDbContext _eCommerceDbContext;

	public IUserRepository Users { get; }

	public IProductRepository Products { get; }

	public IPaymentRepository Payments { get; }

	public IAddressRepository Addresses { get; }

	public ICategoryRepository Category { get; }

	public IOrderRepository Order { get; }

	public IOrderItemRepository OrderItem { get; }

	public IProductImageRepository ProductImage { get; }

	public UnitOfWork(ECommerceSystemDbContext eCommerceDbContext, IUserRepository user, IOrderItemRepository orderItem, IProductImageRepository productImage, IOrderRepository order, ICategoryRepository category, IAddressRepository address, IPaymentRepository payment, IProductRepository product)
	{
		_eCommerceDbContext = eCommerceDbContext;
		Users = user;
		OrderItem = orderItem;
		ProductImage = productImage;
		Order = order;
		Category = category;
		Addresses = address;
		Payments = payment;
		Products = product;
	}

	public Task<int> CompleteAsync()
	{
		int result = _eCommerceDbContext.SaveChanges();
		return Task.FromResult(result);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			_eCommerceDbContext?.Dispose();
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}
}
