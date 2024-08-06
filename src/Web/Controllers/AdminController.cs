using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Application.Interfaces;
using Application.Models.Request;
using Application.Models;
using Domain.Exceptions; 
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    [ApiController]
    [Authorize(Roles = "SysAdmin, Admin")]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Admin>> GetAdmins()
        {
            try
            {
                var admins = _adminService.GetAllAdmins();
                return Ok(admins);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<AdminDTO> GetAdminById(int id)
        {
            try
            {
                var admin = _adminService.GetAdminById(id);
                if (admin == null)
                {
                    throw new NotFoundException("Admin", id);
                }
                return Ok(admin);
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
        public ActionResult<Admin> AddAdmin([FromBody] AdminCreateRequest adminCreateRequest)
        {
            try
            {
                _adminService.CreateAdmin(adminCreateRequest);
                return Ok();
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpPut("{id}")]
        
        public IActionResult UpdateAdmin(int id, [FromBody] AdminUpdateRequest adminUpdateRequest)
        {
            try
            {
                _adminService.UpdateAdmin(id, adminUpdateRequest);
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
        
        public IActionResult DeleteAdmin(int id)
        {
            try
            {
                _adminService.DeleteAdmin(id);
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
