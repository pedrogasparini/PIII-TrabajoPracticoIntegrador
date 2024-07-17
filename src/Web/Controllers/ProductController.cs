using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private List<Product> _products; // Simulación de una lista de productos (en un escenario real usarías una base de datos)

    public ProductController()
    {
        // Inicialización de productos de ejemplo
        _products = new List<Product>
        {
            new Product { ProductId = 1, Name = "Product A", Description = "Description A", Price = 10.50m, Stock = 100 },
            new Product { ProductId = 2, Name = "Product B", Description = "Description B", Price = 15.75m, Stock = 50 }
        };
    }

    // GET api/product
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_products);
    }

    // GET api/product/{id}
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var product = _products.FirstOrDefault(p => p.ProductId == id);
        if (product == null)
            return NotFound();

        return Ok(product);
    }

    // POST api/product
    [HttpPost]
    public IActionResult Post([FromBody] Product product)
    {
        _products.Add(product);
        return CreatedAtAction(nameof(GetById), new { id = product.ProductId }, product);
    }

    // PUT api/product/{id}
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Product product)
    {
        var existingProduct = _products.FirstOrDefault(p => p.ProductId == id);
        if (existingProduct == null)
            return NotFound();

        existingProduct.Name = product.Name;
        existingProduct.Description = product.Description;
        existingProduct.Price = product.Price;
        existingProduct.Stock = product.Stock;

        return NoContent();
    }

    // DELETE api/product/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var product = _products.FirstOrDefault(p => p.ProductId == id);
        if (product == null)
            return NotFound();

        _products.Remove(product);
        return NoContent();
    }
}

