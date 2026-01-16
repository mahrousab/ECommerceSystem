using EcommerceSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.SeedingData;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
	public void Configure(EntityTypeBuilder<OrderItem> builder)
	{
		builder.HasData(new OrderItem
		{
			Id = 1,
			OrderId = 1,
			ProductId = 1,
			Quantity = 1,
			Price = 45000m
		}, new OrderItem
		{
			Id = 2,
			OrderId = 2,
			ProductId = 2,
			Quantity = 2,
			Price = 42000m
		}, new OrderItem
		{
			Id = 3,
			OrderId = 3,
			ProductId = 3,
			Quantity = 3,
			Price = 42030m
		});
	}
}
