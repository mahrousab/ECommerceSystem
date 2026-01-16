using System;
using EcommerceSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.SeedingData;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
	public void Configure(EntityTypeBuilder<Order> builder)
	{
		builder.HasData(new Order
		{
			Id = 1,
			UserId = 1,
			Status = "Paid",
			TotalPrice = 4000m,
			CreatedAt = new DateTime(2024, 8, 1)
		}, new Order
		{
			Id = 2,
			UserId = 2,
			Status = "Not Paid",
			TotalPrice = 41300m,
			CreatedAt = new DateTime(2024, 5, 1)
		}, new Order
		{
			Id = 3,
			UserId = 3,
			Status = "Not Paid",
			TotalPrice = 45300m,
			CreatedAt = new DateTime(2024, 3, 1)
		});
	}
}
