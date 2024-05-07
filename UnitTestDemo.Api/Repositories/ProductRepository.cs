using Microsoft.EntityFrameworkCore;
using UnitTestDemo.Api.Data;

namespace UnitTestDemo.Api.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly TestDbContext _context;

    public ProductRepository(TestDbContext context)
    {
       _context = context;
    }

    public async Task AddAsync(Product product) => await _context.Products.AddAsync(product);

    public Task AddRangeAsync(List<Product> products) => _context.Products.AddRangeAsync(products);

    public Task<List<Product>> GetAllAsync() => _context.Products.ToListAsync();

    public Task<Product?> GetByIdAsync(int id) => _context.Products.FirstAsync(p => p.Id == id);

    public void SoftRemove(Product product) => _context.Products.Remove(product);

    public void SoftRemoveRange(List<Product> products) => _context.Products.RemoveRange(products);

    public void Update(Product product) => _context.Products.Update(product);

    public void UpdateRange(List<Product> products) => _context.Products.UpdateRange(products);
    public async Task<int> SaveChangeAsync() => await _context.SaveChangesAsync();
}
