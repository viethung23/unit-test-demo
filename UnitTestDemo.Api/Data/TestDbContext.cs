using Microsoft.EntityFrameworkCore;

namespace UnitTestDemo.Api.Data;

public class TestDbContext : DbContext
{
    public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasData(
        new Product { Id = 1, Name = "produc 1", Description = "Hamlet", Price = 70000 },
        new Product { Id = 2, Name = "produc 2", Description = "King Lear", Price = 40000 },
        new Product { Id = 3, Name = "produc 3", Description = "Othello", Price = 58000 });
    }
}
