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
        var sysadmins = _sysadminService.GetAllSysAdmins();
        return Ok(sysadmins);
    }

    [HttpGet("{id}")]
    public ActionResult<SysAdminDTO> GetSysAdminById(int id)
    {
        return _sysadminService.GetSysAdminById(id);
    }

    [HttpPost]
    public ActionResult<SysAdmin> AddSysAdmin(SysAdminCreateRequest sysadminCreateRequest)
    {
        try
        {
            _sysadminService.CreateSysAdmin(sysadminCreateRequest);
            return Ok();
        }
        catch (System.Exception)
        {
            return BadRequest();
        }
    }


    [HttpPut("{id}")]
    public IActionResult UpdateSysAdmin(int id, SysAdminUpdateRequest sysadminUpdateRequest)
    {
        try
        {
            _sysadminService.UpdateSysAdmin(id, sysadminUpdateRequest);
            return Ok();
        }
        catch (System.Exception)
        {
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteSysAdmin(int id)
    {
        try
        {
            _sysadminService.DeleteSysAdmin(id);
            return Ok();
        }
        catch (System.Exception)
        {
            return NotFound();
        }
    }
}