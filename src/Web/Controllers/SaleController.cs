using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class SaleController : ControllerBase
{
    private List<Sale> _sales; // Simulación de una lista de ventas (en un escenario real usarías una base de datos)

    public SaleController()
    {
        // Inicialización de ventas de ejemplo
        _sales = new List<Sale>();
    }

    // GET api/sale
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_sales);
    }

    // GET api/sale/{id}
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var sale = _sales.FirstOrDefault(s => s.SaleId == id);
        if (sale == null)
            return NotFound();

        return Ok(sale);
    }

    // POST api/sale
    [HttpPost]
    public IActionResult Post([FromBody] Sale sale)
    {
        sale.SaleId = _sales.Count + 1; // Simulación de generación de ID
        sale.SaleDate = DateTime.Now; // Fecha actual

        // Simulación de lógica para calcular detalles de venta, actualizar stock, etc.

        _sales.Add(sale);
        return CreatedAtAction(nameof(GetById), new { id = sale.SaleId }, sale);
    }
}
