using Microsoft.AspNetCore.Mvc;
using Application.Models.Request;
using Application.Services;
using System;
using Application.Interfaces;

namespace YourApplication.Controllers
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
        public IActionResult GetAllSaleDetails()
        {
            var saleDetails = _saleDetailService.GetAllSaleDetails();
            return Ok(saleDetails);
        }

        [HttpGet("{id}")]
        public IActionResult GetSaleDetailById(int id)
        {
            var saleDetail = _saleDetailService.GetSaleDetailById(id);
            if (saleDetail == null)
            {
                return NotFound();
            }
            return Ok(saleDetail);
        }

        [HttpPost]
        public IActionResult CreateSaleDetail([FromBody] SaleDetailCreateRequest saleDetailCreateRequest)
        {
            try
            {
                _saleDetailService.CreateSaleDetail(saleDetailCreateRequest);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSaleDetail(int id, [FromBody] SaleDetailUpdateRequest saleDetailUpdateRequest)
        {
            try
            {
                _saleDetailService.UpdateSaleDetail(id, saleDetailUpdateRequest);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSaleDetail(int id)
        {
            try
            {
                _saleDetailService.DeleteSaleDetail(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

