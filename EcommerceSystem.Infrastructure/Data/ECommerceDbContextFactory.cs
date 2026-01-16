using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EcommerceSystem.Infrastructure.Data;

public class ECommerceSystemDbContextFactory : IDesignTimeDbContextFactory<ECommerceSystemDbContext>
{
    public ECommerceSystemDbContext CreateDbContext(string[] args)
	{
		DbContextOptionsBuilder<ECommerceSystemDbContext> optionsBuilder = new DbContextOptionsBuilder<ECommerceSystemDbContext>();
		optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EcommerceSystemDatabase;Trusted_Connection=True;TrustServerCertificate=True");
		return new ECommerceSystemDbContext(optionsBuilder.Options);
	}
}
