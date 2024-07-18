
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Html;
using Domain.Entities;
using Application.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetProducts()
    {
        var products = _productService.GetAllProducts();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetProductById(int id)
    {
        var product = _productService.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpPost]
    public ActionResult<Product> AddProduct(Product product)
    {
        _productService.AddProduct(product);
        return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id, Product product)
    {
        if (id != product.Id)
        {
            return BadRequest();
        }

        _productService.UpdateProduct(product);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(int id)
    {
        var product = _productService.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }

        _productService.DeleteProduct(id);
        return NoContent();
    }
}
