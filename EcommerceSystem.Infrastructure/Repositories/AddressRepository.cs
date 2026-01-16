using Ecommerce.Application.IRepository;
using EcommerceSystem.Domain.Models;
using EcommerceSystem.Infrastructure.Data;

namespace Ecommerce.Application.Repository;

public class AddressRepository : GenericRepository<Address>, IAddressRepository, IGenericRepository<Address>
{
	public AddressRepository(ECommerceSystemDbContext context)
		: base(context)
	{
	}
}
