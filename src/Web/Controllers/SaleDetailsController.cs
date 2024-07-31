using Microsoft.AspNetCore.Mvc;
using Application.Models.Request;
using Application.Services;
using Application.Interfaces;
using Domain.Exceptions; 
using System;
using System.Collections.Generic;
using Application.Models;
using Domain.Entities;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleDetailController : ControllerBase
    {
        private readonly ISaleDetailService _saleDetailService;

        public SaleDetailController(ISaleDetailService saleDetailService)
        {
            _saleDetailService = saleDetailService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SaleDetail>> GetAllSaleDetails()
        {
            try
            {
                var saleDetails = _saleDetailService.GetAllSaleDetails();
                return Ok(saleDetails);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<SaleDetailDTO> GetSaleDetailById(int id)
        {
            try
            {
                var saleDetail = _saleDetailService.GetSaleDetailById(id);
                if (saleDetail == null)
                {
                    throw new NotFoundException("SaleDetail", id);
                }
                return Ok(saleDetail);
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
        public ActionResult CreateSaleDetail([FromBody] SaleDetailCreateRequest saleDetailCreateRequest)
        {
            try
            {
                _saleDetailService.CreateSaleDetail(saleDetailCreateRequest);
                return Ok();
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSaleDetail(int id, [FromBody] SaleDetailUpdateRequest saleDetailUpdateRequest)
        {
            try
            {
                _saleDetailService.UpdateSaleDetail(id, saleDetailUpdateRequest);
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
        public IActionResult DeleteSaleDetail(int id)
        {
            try
            {
                _saleDetailService.DeleteSaleDetail(id);
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
