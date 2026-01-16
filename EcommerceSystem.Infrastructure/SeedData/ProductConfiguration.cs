using EcommerceSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infrastructure.SeedingData;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
	public void Configure(EntityTypeBuilder<Product> builder)
	{
		builder.HasData(new Product
		{
			Id = 1,
			Name = "iPhone 12",
			Description = "Latest Apple iPhone",
			Price = 45000m,
			Stock = 10,
			CategoryId = 1
		}, new Product
		{
			Id = 2,
			Name = "Samsung Smart TV",
			Description = "55 inch 4K TV",
			Price = 30000m,
			Stock = 5,
			CategoryId = 1
		}, new Product
		{
			Id = 3,
			Name = "iPhone 14",
			Description = "Latest Apple iPhone",
			Price = 45000m,
			Stock = 10,
			CategoryId = 1
		}, new Product
		{
			Id = 4,
			Name = "Dell XPS 13",
			Description = "High-performance laptop",
			Price = 60000m,
			Stock = 7,
			CategoryId = 2
		}, new Product
		{
			Id = 5,
			Name = "Sony WH-1000XM4",
			Description = "Noise-cancelling headphones",
			Price = 20000m,
			Stock = 15,
			CategoryId = 3
		}, new Product
		{
			Id = 6,
			Name = "Apple MacBook Pro",
			Description = "Powerful laptop for professionals",
			Price = 120000m,
			Stock = 4,
			CategoryId = 2
		}, new Product
		{
			Id = 7,
			Name = "Google Pixel 6",
			Description = "Google's flagship smartphone",
			Price = 40000m,
			Stock = 8,
			CategoryId = 1
		}, new Product
		{
			Id = 8,
			Name = "Bose QuietComfort 35 II",
			Description = "Wireless Bluetooth Headphones",
			Price = 18000m,
			Stock = 12,
			CategoryId = 3
		}, new Product
		{
			Id = 9,
			Name = "HP Spectre x360",
			Description = "Convertible laptop with touch screen",
			Price = 75000m,
			Stock = 6,
			CategoryId = 2
		}, new Product
		{
			Id = 10,
			Name = "OnePlus 9 Pro",
			Description = "High-end smartphone with fast performance",
			Price = 50000m,
			Stock = 9,
			CategoryId = 1
		}, new Product
		{
			Id = 11,
			Name = "LG OLED TV",
			Description = "65 inch OLED 4K TV",
			Price = 80000m,
			Stock = 3,
			CategoryId = 1
		}, new Product
		{
			Id = 12,
			Name = "Asus ROG Zephyrus G14",
			Description = "Gaming laptop with powerful GPU",
			Price = 95000m,
			Stock = 5,
			CategoryId = 2
		}, new Product
		{
			Id = 13,
			Name = "JBL Flip 5",
			Description = "Portable Bluetooth Speaker",
			Price = 7000m,
			Stock = 20,
			CategoryId = 3
		}, new Product
		{
			Id = 14,
			Name = "Microsoft Surface Laptop 4",
			Description = "Sleek laptop with touchscreen",
			Price = 85000m,
			Stock = 4,
			CategoryId = 2
		}, new Product
		{
			Id = 15,
			Name = "Sony Xperia 1 III",
			Description = "Premium smartphone with advanced camera",
			Price = 60000m,
			Stock = 7,
			CategoryId = 1
		}, new Product
		{
			Id = 16,
			Name = "Beats Solo Pro",
			Description = "On-ear noise cancelling headphones",
			Price = 15000m,
			Stock = 10,
			CategoryId = 3
		}, new Product
		{
			Id = 17,
			Name = "Lenovo ThinkPad X1 Carbon",
			Description = "Business laptop with robust features",
			Price = 110000m,
			Stock = 11,
			CategoryId = 2
		}, new Product
		{
			Id = 18,
			Name = "T-Shirt",
			Description = "Cotton T-Shirt",
			Price = 300m,
			Stock = 50,
			CategoryId = 2
		}, new Product
		{
			Id = 19,
			Name = "Jeans",
			Description = "Denim Jeans",
			Price = 1200m,
			Stock = 40,
			CategoryId = 2
		}, new Product
		{
			Id = 20,
			Name = "Sneakers",
			Description = "Running Sneakers",
			Price = 2500m,
			Stock = 30,
			CategoryId = 2
		}, new Product
		{
			Id = 21,
			Name = "Jacket",
			Description = "Leather Jacket",
			Price = 5000m,
			Stock = 20,
			CategoryId = 2
		}, new Product
		{
			Id = 22,
			Name = "Hat",
			Description = "Baseball Cap",
			Price = 800m,
			Stock = 60,
			CategoryId = 2
		}, new Product
		{
			Id = 23,
			Name = "Sunglasses",
			Description = "Polarized Sunglasses",
			Price = 1500m,
			Stock = 25,
			CategoryId = 2
		}, new Product
		{
			Id = 24,
			Name = "Watch",
			Description = "Digital Watch",
			Price = 3000m,
			Stock = 15,
			CategoryId = 2
		}, new Product
		{
			Id = 25,
			Name = "Belt",
			Description = "Leather Belt",
			Price = 700m,
			Stock = 35,
			CategoryId = 2
		}, new Product
		{
			Id = 26,
			Name = "Scarf",
			Description = "Wool Scarf",
			Price = 600m,
			Stock = 45,
			CategoryId = 2
		}, new Product
		{
			Id = 27,
			Name = "Gloves",
			Description = "Winter Gloves",
			Price = 400m,
			Stock = 55,
			CategoryId = 2
		}, new Product
		{
			Id = 28,
			Name = "Socks",
			Description = "Cotton Socks",
			Price = 200m,
			Stock = 70,
			CategoryId = 2
		}, new Product
		{
			Id = 29,
			Name = "Dress",
			Description = "Evening Dress",
			Price = 4000m,
			Stock = 18,
			CategoryId = 2
		}, new Product
		{
			Id = 30,
			Name = "Skirt",
			Description = "Denim Skirt",
			Price = 1500m,
			Stock = 22,
			CategoryId = 2
		});
	}
}
