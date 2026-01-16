using EcommerceSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.SeedingData;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
	public void Configure(EntityTypeBuilder<Address> builder)
	{
		builder.HasData(new Address
		{
			Id = 1,
			UserId = 1,
			Country = "Egypt",
			City = "Cairo",
			Street = "Nasr City",
			PostalCode = "11765"
		}, new Address
		{
			Id = 2,
			UserId = 2,
			Country = "Qalyopia",
			City = "shipin Elqanter",
			Street = "Hussin Roshdy",
			PostalCode = "13713"
		});
	}
}
