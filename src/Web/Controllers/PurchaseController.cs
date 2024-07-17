using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class PurchaseController : ControllerBase
{
    private List<Purchase> _purchases; // Simulación de una lista de compras (en un escenario real usarías una base de datos)

    public PurchaseController()
    {
        // Inicialización de compras de ejemplo
        _purchases = new List<Purchase>();
    }

    // GET api/purchase
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_purchases);
    }

    // GET api/purchase/{id}
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var purchase = _purchases.FirstOrDefault(p => p.PurchaseId == id);
        if (purchase == null)
            return NotFound();

        return Ok(purchase);
    }

    // POST api/purchase
    [HttpPost]
    public IActionResult Post([FromBody] Purchase purchase)
    {
        purchase.PurchaseId = _purchases.Count + 1; // Simulación de generación de ID
        purchase.PurchaseDate = DateTime.Now; // Fecha actual

        // Simulación de lógica para actualizar stock, registrar proveedores, etc.

        _purchases.Add(purchase);
        return CreatedAtAction(nameof(GetById), new { id = purchase.PurchaseId }, purchase);
    }
}

