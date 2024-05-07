using UnitTestDemo.Api.Data;

namespace UnitTestDemo.Api.Repositories;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task AddAsync(Product product);
    void Update(Product product);
    void UpdateRange(List<Product> products);
    void SoftRemove(Product product);
    Task AddRangeAsync(List<Product> products);
    void SoftRemoveRange(List<Product> products);
    Task<int> SaveChangeAsync();
}
