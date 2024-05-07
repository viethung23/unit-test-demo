using Microsoft.AspNetCore.Mvc;
using UnitTestDemo.Api.Models;
using UnitTestDemo.Api.Services;

namespace UnitTestDemo.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductRequest request)
    {
        var response = await _productService.CreateProduct(request);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var response = await _productService.GetProducts();
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var response = await _productService.GetProduct(id);
        return Ok(response);
    }
}
