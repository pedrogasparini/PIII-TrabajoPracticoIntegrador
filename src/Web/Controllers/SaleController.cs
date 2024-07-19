using Microsoft.AspNetCore.Mvc;
using Application.Models.Request;
using Application.Services;
using System;
using Application.Interfaces;

namespace YourApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet]
        public IActionResult GetAllSales()
        {
            var sales = _saleService.GetAllSales();
            return Ok(sales);
        }

        [HttpGet("{id}")]
        public IActionResult GetSaleById(int id)
        {
            var sale = _saleService.GetSaleById(id);
            if (sale == null)
            {
                return NotFound();
            }
            return Ok(sale);
        }

        [HttpPost]
        public IActionResult CreateSale( SaleCreateRequest saleCreateRequest)
        {
            try
            {
                _saleService.CreateSale(saleCreateRequest);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSale(int id, [FromBody] SaleUpdateRequest saleUpdateRequest)
        {
            try
            {
                _saleService.UpdateSale(id, saleUpdateRequest);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSale(int id)
        {
            try
            {
                _saleService.DeleteSale(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
