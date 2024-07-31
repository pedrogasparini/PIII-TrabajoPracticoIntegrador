using Microsoft.AspNetCore.Mvc;
using Application.Models.Request;
using Application.Services;
using Application.Interfaces;
using Domain.Exceptions;
using System;

namespace Web.Controllers
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
            try
            {
                var sales = _saleService.GetAllSales();
                return Ok(sales);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetSaleById(int id)
        {
            try
            {
                var sale = _saleService.GetSaleById(id);
                if (sale == null)
                {
                    throw new NotFoundException("Sale", id);
                }
                return Ok(sale);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpPost]
        public IActionResult CreateSale(SaleCreateRequest saleCreateRequest)
        {
            try
            {
                _saleService.CreateSale(saleCreateRequest);
                return Ok();
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSale(int id, [FromBody] SaleUpdateRequest saleUpdateRequest)
        {
            try
            {
                _saleService.UpdateSale(id, saleUpdateRequest);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSale(int id)
        {
            try
            {
                _saleService.DeleteSale(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "An unexpected error occurred.");
            }
        }
    }
}
