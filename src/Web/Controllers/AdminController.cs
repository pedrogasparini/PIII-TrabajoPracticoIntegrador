using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Html;
using Domain.Entities;
using Application.Interfaces;

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
    public ActionResult<Admin> GetAdminById(int id)
    {
        var admin = _adminService.GetAdminById(id);
        if (admin == null)
        {
            return NotFound();
        }
        return Ok(admin);
    }

    [HttpPost]
    public ActionResult<Admin> AddAdmin(Admin admin)
    {
        _adminService.CreateAdmin(admin);
        return CreatedAtAction(nameof(GetAdminById), new { id = admin.Id }, admin);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAdmin(int id, Admin admin)
    {
        if (id != admin.Id)
        {
            return BadRequest();
        }

        _adminService.UpdateAdmin(admin);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAdmin(int id)
    {
        var admin = _adminService.GetAdminById(id);
        if (admin == null)
        {
            return NotFound();
        }

        _adminService.DeleteAdmin(id);
        return NoContent();
    }
}

