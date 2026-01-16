using System;
using EcommerceSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.SeedingData;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
	public void Configure(EntityTypeBuilder<Payment> builder)
	{
		builder.HasData(new Payment
		{
			Id = 1,
			OrderId = 1,
			PaymentMethod = "Credit Card",
			PaymentStatus = "Completed",
			PaidAt = new DateTime(2025, 1, 2)
		}, new Payment
		{
			Id = 2,
			OrderId = 2,
			PaymentMethod = "Vodafon Cash",
			PaymentStatus = "Completed",
			PaidAt = new DateTime(2025, 4, 2)
		}, new Payment
		{
			Id = 3,
			OrderId = 3,
			PaymentMethod = "Orange Cash",
			PaymentStatus = "Completed",
			PaidAt = new DateTime(2025, 9, 2)
		});
	}
}
