using Ecommerce.Domain.Models;
using EcommerceSystem.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EcommerceSystem.Infrastructure.Data;

public class ECommerceSystemDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
    public DbSet<User> Users { get; set; }

	public DbSet<Address> Addresses { get; set; }

	public DbSet<Category> Categories { get; set; }

	public DbSet<Product> Products { get; set; }

	public DbSet<ProductImage> ProductImages { get; set; }

	public DbSet<Order> Orders { get; set; }

	public DbSet<OrderItem> OrderItems { get; set; }

	public DbSet<Payment> Payments { get; set; }
	
	public ECommerceSystemDbContext(DbContextOptions<ECommerceSystemDbContext> options)
		: base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(ECommerceSystemDbContext).Assembly);
	}
}
