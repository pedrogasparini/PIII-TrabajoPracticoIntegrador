using Microsoft.AspNetCore.Mvc;
using Application.Models.Request;
using Application.Services;
using Application.Interfaces;
using Domain.Exceptions; 
using System;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Authorize(Roles = "Client, SysAdmin, Admin")]
        public IActionResult GetAllProducts()
        {
            try
            {
                var products = _productService.GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Client, SysAdmin, Admin")]
        public IActionResult GetProductById(int id)
        {
            try
            {
                var product = _productService.GetProductById(id);
                if (product == null)
                {
                    throw new NotFoundException("Product", id);
                }
                return Ok(product);
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
        [Authorize(Roles = "SysAdmin, Admin")]
        public IActionResult CreateProduct([FromBody] ProductCreateRequest productCreateRequest)
        {
            try
            {
                _productService.CreateProduct(productCreateRequest);
                return Ok();
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "SysAdmin, Admin")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductUpdateRequest productUpdateRequest)
        {
            try
            {
                _productService.UpdateProduct(id, productUpdateRequest);
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
        [Authorize(Roles = "SysAdmin, Admin")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                _productService.DeleteProduct(id);
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
