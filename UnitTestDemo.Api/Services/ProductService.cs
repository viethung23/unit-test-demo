using MapsterMapper;
using UnitTestDemo.Api.Data;
using UnitTestDemo.Api.Models;
using UnitTestDemo.Api.Repositories;

namespace UnitTestDemo.Api.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ProductResponse?> CreateProduct(CreateProductRequest request)
    {
        var product = _mapper.Map<Product>(request);
        await _productRepository.AddAsync(product);
        var isSuccess = await _productRepository.SaveChangeAsync() > 0;
        if (isSuccess)
        {
            return _mapper.Map<ProductResponse>(request);
        }
        return null;
    }

    public async Task<ProductResponse> GetProduct(int productId)
    {
        var product = await _productRepository.GetByIdAsync(productId);
        return _mapper.Map<ProductResponse>(product);
    }

    public async Task<List<ProductResponse>> GetProducts()
    {
        var products = await _productRepository.GetAllAsync();
        return _mapper.Map<List<ProductResponse>>(products);
    }
}
