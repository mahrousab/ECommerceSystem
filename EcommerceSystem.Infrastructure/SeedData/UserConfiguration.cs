using System;
using Ecommerce.Domain.Models;
using EcommerceSystem.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.SeedingData;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder.HasData(new User
		{
			Id = 1,
			Name = "Ahmed Ali",
			Email = "ahmed@email.com",
			PasswordHash = "hashed123",
			Phone = "0100000000",
			CreatedAt = new DateTime(2026, 1, 2)
		}, new User
		{
			Id = 2,
			Name = "Sara Mohamed",
			Email = "sara@email.com",
			PasswordHash = "hashed456",
			Phone = "0111111111",
			CreatedAt = new DateTime(2026, 1, 2)
		}, new User
		{
			Id = 3,
			Name = "Omar Hassan",
			Email = "Omar@email.com",
			PasswordHash = "hashed789",
			Phone = "0122222222",
			CreatedAt = new DateTime(2026, 1, 2)
		}, new User
		{
			Id = 4,
			Name = "Laila Youssef",
			Email = "laila@email.com",
			PasswordHash = "hashed321",
			Phone = "0133333333",
			CreatedAt = new DateTime(2026, 1, 2)
		}, new User
		{
			Id = 5,
			Name = "mahrous Ellithy",
			Email = "mahrousellithy99@gmail.com",
			PasswordHash = "mahroushed321",
			Phone = "01027782815",
			CreatedAt = new DateTime(2026, 1, 2)
		}, new User
		{
			Id = 6,
			Name = "Hazem Farag",
			Email = "HazemFarag@mail.com",
			PasswordHash = "hashed654",
			Phone = "0144444444",
			CreatedAt = new DateTime(2026, 1, 2)
		}, new User
		{
			Id = 7,
			Name = "mahmoud tofaha",
			Email = "Tofaha@gmail.com",
			PasswordHash = "hashed987",
			Phone = "0155555555",
			CreatedAt = new DateTime(2026, 1, 2)
		});
	}
}
