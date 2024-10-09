using voedselverspilling.Domain.Models;
using voedselverspilling.DomainServices;
using Microsoft.AspNetCore.Mvc;

namespace voedselverspilling.WebAPI.Controllers
{

[ApiController]
[Route("api/Product")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductRepository _productRepository;

    public ProductController(ILogger<ProductController> logger, IProductRepository productRepository)
    {
        _productRepository = productRepository;
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Product> Get()
    {
        return _productRepository.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<Product> GetById(int id)
    {
       return await _productRepository.GetByIdAsync(id);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> Post(Product product)
    {
        await _productRepository.AddAsync(product);
        return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
    }

    [HttpPut]
    public async Task<IActionResult> Put(Product product)
    {
        await _productRepository.UpdateAsync(product);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null) return NotFound();

        _productRepository.RemoveAsync(product);
        return NoContent();
    }
}

}
