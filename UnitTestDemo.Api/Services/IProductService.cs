using UnitTestDemo.Api.Data;
using UnitTestDemo.Api.Models;

namespace UnitTestDemo.Api.Services;

public interface IProductService
{
    public Task<ProductResponse> GetProduct(int productId);
    public Task<List<ProductResponse>> GetProducts();
    public Task<ProductResponse?> CreateProduct(CreateProductRequest request);
}
