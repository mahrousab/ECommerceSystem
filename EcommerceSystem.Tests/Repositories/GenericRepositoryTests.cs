using Ecommerce.Application.Repository;
using EcommerceSystem.Domain.Models;
using FluentAssertions;

public class GenericRepositoryTests : TestDbContextBase
{
    private readonly GenericRepository<Product> _repository;

    public GenericRepositoryTests()
    {
        _repository = new GenericRepository<Product>(_context);
    }

    [Fact]
    public void Add_ShouldAddEntity()
    {
        // Arrange
        var product = new Product { Name = "Laptop", Price = 1000 };

        // Act
        _repository.Add(product);
        _context.SaveChanges();

        // Assert
        _context.Products.Should().HaveCount(1);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllItems()
    {
        // Arrange
        _context.Products.AddRange(
            new Product { Name = "P1" },
            new Product { Name = "P2" }
        );
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.GetAllAsync();

        // Assert
        result.Should().HaveCount(2);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnCorrectEntity()
    {
        // Arrange
        var product = new Product { Name = "Phone" };
        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.GetByIdAsync(product.Id);

        // Assert
        result.Should().NotBeNull();
        result!.Name.Should().Be("Phone");
    }

    [Fact]
    public async Task FindAsync_ShouldReturnMatchingEntity()
    {
        // Arrange
        _context.Products.AddRange(
            new Product { Name = "TV" },
            new Product { Name = "Laptop" }
        );
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.FindAsync(p => p.Name == "Laptop");

        // Assert
        result.Should().NotBeNull();
        result!.Name.Should().Be("Laptop");
    }

    [Fact]
    public async Task CountAsync_ShouldReturnCorrectCount()
    {
        // Arrange
        _context.Products.AddRange(
            new Product(),
            new Product(),
            new Product()
        );
        await _context.SaveChangesAsync();

        // Act
        var count = await _repository.CountAsync();

        // Assert
        count.Should().Be(3);
    }

    [Fact]
    public void Delete_ShouldRemoveEntity()
    {
        // Arrange
        var product = new Product { Name = "Tablet" };
        _context.Products.Add(product);
        _context.SaveChanges();

        // Act
        _repository.Delete(product);
        _context.SaveChanges();

        // Assert
        _context.Products.Should().BeEmpty();
    }
}
