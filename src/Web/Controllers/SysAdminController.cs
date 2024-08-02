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
    [Authorize(Roles = "SysAdmin")]
    [Route("api/[controller]")]
    public class SysAdminController : ControllerBase
    {
        private readonly ISysAdminService _sysadminService;

        public SysAdminController(ISysAdminService sysadminService)
        {
            _sysadminService = sysadminService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SysAdmin>> GetSysAdmins()
        {
            try
            {
                var sysadmins = _sysadminService.GetAllSysAdmins();
                return Ok(sysadmins);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<SysAdminDTO> GetSysAdminById(int id)
        {
            try
            {
                var sysadmin = _sysadminService.GetSysAdminById(id);
                if (sysadmin == null)
                {
                    throw new NotFoundException("SysAdmin", id);
                }
                return Ok(sysadmin);
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
        public ActionResult<SysAdmin> AddSysAdmin([FromBody] SysAdminCreateRequest sysadminCreateRequest)
        {
            try
            {
                _sysadminService.CreateSysAdmin(sysadminCreateRequest);
                return Ok();
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSysAdmin(int id, [FromBody] SysAdminUpdateRequest sysadminUpdateRequest)
        {
            try
            {
                _sysadminService.UpdateSysAdmin(id, sysadminUpdateRequest);
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
        public IActionResult DeleteSysAdmin(int id)
        {
            try
            {
                _sysadminService.DeleteSysAdmin(id);
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
