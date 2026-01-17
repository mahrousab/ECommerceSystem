using Ecommerce.Application.IRepository;
using Ecommerce.Domain.Models;
using EcommerceSystem.Domain.Models;
using EcommerceSystem.Infrastructure.Data;


namespace Ecommerce.Application.Repository;

public class UserRepository : GenericRepository<User>, IUserRepository, IGenericRepository<User>
{
	public UserRepository(ECommerceSystemDbContext eCommerceDbContext)
		: base(eCommerceDbContext)
	{
	}
}
