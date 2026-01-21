using Microsoft.EntityFrameworkCore;
using EcommerceSystem.Domain.Models;

namespace EcommerceSystem.Tests.Infrastructure
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(options)
        {
        }

       
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();

        
    }
}
