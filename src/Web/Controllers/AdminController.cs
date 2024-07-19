using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Html;
using Domain.Entities;
using Application.Interfaces;
using Application.Models.Request;
using System.Security.Claims;
using Application.Models;

[ApiController]
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
        var admins = _adminService.GetAllAdmins();
        return Ok(admins);
    }

    [HttpGet("{id}")]
    public ActionResult<AdminDTO> GetAdminById(int id)
    {
        return _adminService.GetAdminById(id);
    }

    [HttpPost]
    public ActionResult<Admin> AddAdmin(AdminCreateRequest adminCreateRequest)
    {
        try
        {
            _adminService.CreateAdmin(adminCreateRequest);
            return Ok();
        }
        catch (System.Exception )
        {
            return  BadRequest();
        }
    }


    [HttpPut("{id}")]
    public IActionResult UpdateAdmin(int id, AdminUpdateRequest adminUpdateRequest)
    {
        try
        {
            _adminService.UpdateAdmin(id, adminUpdateRequest);
            return Ok();
        }
        catch (System.Exception)
        {
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAdmin(int id)
    {
        try
        {
            _adminService.DeleteAdmin(id);
            return Ok();
        }
        catch (System.Exception)
        {
            return NotFound();
        }
    }
}

