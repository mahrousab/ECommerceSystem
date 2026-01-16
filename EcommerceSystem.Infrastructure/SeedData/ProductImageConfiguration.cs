using EcommerceSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.SeedingData;

public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
{
	public void Configure(EntityTypeBuilder<ProductImage> builder)
	{
		builder.HasData(new ProductImage
		{
			Id = 1,
			ProductId = 1,
			ImageUrl = "https://example.com/images/iphone12-front.jpg"
		}, new ProductImage
		{
			Id = 2,
			ProductId = 1,
			ImageUrl = "https://example.com/images/iphone12-back.jpg"
		}, new ProductImage
		{
			Id = 3,
			ProductId = 2,
			ImageUrl = "https://example.com/images/samsung-tv.jpg"
		}, new ProductImage
		{
			Id = 4,
			ProductId = 3,
			ImageUrl = "https://example.com/images/iphone14-front.jpg"
		}, new ProductImage
		{
			Id = 5,
			ProductId = 3,
			ImageUrl = "https://example.com/images/iphone14-back.jpg"
		}, new ProductImage
		{
			Id = 6,
			ProductId = 4,
			ImageUrl = "https://example.com/images/dell-xps13.jpg"
		}, new ProductImage
		{
			Id = 7,
			ProductId = 5,
			ImageUrl = "https://example.com/images/sony-headphones.jpg"
		}, new ProductImage
		{
			Id = 8,
			ProductId = 6,
			ImageUrl = "https://example.com/images/apple-watch.jpg"
		}, new ProductImage
		{
			Id = 9,
			ProductId = 7,
			ImageUrl = "https://example.com/images/google-pixel6-front.jpg"
		}, new ProductImage
		{
			Id = 10,
			ProductId = 7,
			ImageUrl = "https://example.com/images/google-pixel6-back.jpg"
		}, new ProductImage
		{
			Id = 11,
			ProductId = 8,
			ImageUrl = "https://example.com/images/lg-refrigerator.jpg"
		}, new ProductImage
		{
			Id = 12,
			ProductId = 9,
			ImageUrl = "https://example.com/images/amazon-echo.jpg"
		}, new ProductImage
		{
			Id = 13,
			ProductId = 10,
			ImageUrl = "https://example.com/images/nintendo-switch.jpg"
		}, new ProductImage
		{
			Id = 14,
			ProductId = 11,
			ImageUrl = "https://example.com/images/fitbit-charge5.jpg"
		}, new ProductImage
		{
			Id = 15,
			ProductId = 12,
			ImageUrl = "https://example.com/images/sony-playstation5.jpg"
		}, new ProductImage
		{
			Id = 16,
			ProductId = 13,
			ImageUrl = "https://example.com/images/microsoft-surface-pro.jpg"
		}, new ProductImage
		{
			Id = 17,
			ProductId = 14,
			ImageUrl = "https://example.com/images/canon-eos-r5.jpg"
		}, new ProductImage
		{
			Id = 18,
			ProductId = 15,
			ImageUrl = "https://example.com/images/bose-quietcomfort35.jpg"
		}, new ProductImage
		{
			Id = 19,
			ProductId = 16,
			ImageUrl = "https://example.com/images/jbl-flip5.jpg"
		}, new ProductImage
		{
			Id = 20,
			ProductId = 17,
			ImageUrl = "https://example.com/images/anker-powercore-10000.jpg"
		});
	}
}
