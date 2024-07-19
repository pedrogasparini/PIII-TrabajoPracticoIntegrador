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
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Client>> GetClients()
    {
        var clients = _clientService.GetAllClients();
        return Ok(clients);
    }

    [HttpGet("{id}")]
    public ActionResult<ClientDTO> GetClientById(int id)
    {
        return _clientService.GetClientById(id);
    }

    [HttpPost]
    public ActionResult<Client> AddClient(ClientCreateRequest clientCreateRequest)
    {
        try
        {
            _clientService.CreateClient(clientCreateRequest);
            return Ok();
        }
        catch (System.Exception)
        {
            return BadRequest();
        }
    }


    [HttpPut("{id}")]
    public IActionResult UpdateClient(int id, ClientUpdateRequest clientUpdateRequest)
    {
        try
        {
            _clientService.UpdateClient(id, clientUpdateRequest);
            return Ok();
        }
        catch (System.Exception)
        {
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteClient(int id)
    {
        try
        {
            _clientService.DeleteClient(id);
            return Ok();
        }
        catch (System.Exception)
        {
            return NotFound();
        }
    }
}