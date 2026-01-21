using Microsoft.EntityFrameworkCore;
using EcommerceSystem.Infrastructure.Data;

public abstract class TestDbContextBase : IDisposable
{
    protected readonly ECommerceSystemDbContext _context;

    protected TestDbContextBase()
    {
        var options = new DbContextOptionsBuilder<ECommerceSystemDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        _context = new ECommerceSystemDbContext(options);
    }

    public void Dispose()
    {
        _context.Database.EnsureDeleted();
        _context.Dispose();
    }
}
