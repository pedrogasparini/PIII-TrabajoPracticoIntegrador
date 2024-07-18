using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Html;
using Domain.Entities;
using Application.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class SaleController : ControllerBase
{
    private readonly ISaleService _saleService;

    public SaleController(ISaleService saleService)
    {
        _saleService = saleService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Sale>> GetSales()
    {
        var sales = _saleService.GetAllSales();
        return Ok(sales);
    }

    [HttpGet("{id}")]
    public ActionResult<Sale> GetSaleById(int id)
    {
        var sale = _saleService.GetSaleById(id);
        if (sale == null)
        {
            return NotFound();
        }
        return Ok(sale);
    }

    [HttpPost]
    public ActionResult<Sale> AddSale(Sale sale)
    {
        _saleService.AddSale(sale);
        return CreatedAtAction(nameof(GetSaleById), new { id = sale.Id }, sale);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateSale(int id, Sale sale)
    {
        if (id != sale.Id)
        {
            return BadRequest();
        }

        _saleService.UpdateSale(sale);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteSale(int id)
    {
        var sale = _saleService.GetSaleById(id);
        if (sale == null)
        {
            return NotFound();
        }

        _saleService.DeleteSale(id);
        return NoContent();
    }
}

