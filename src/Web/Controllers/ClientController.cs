using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Application.Interfaces;
using Application.Models.Request;
using Application.Models;
using System;
using System.Collections.Generic;
using Domain.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    [ApiController]
    [Authorize(Roles = "SysAdmin")]
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
            try
            {
                var clients = _clientService.GetAllClients();
                return Ok(clients);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ClientDTO> GetClientById(int id)
        {
            try
            {
                var client = _clientService.GetClientById(id);
                if (client == null)
                {
                    throw new NotFoundException("Client", id);
                }
                return Ok(client);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception )
            {
                
                return StatusCode(500, "An unexpected error occurred.");
            }
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult<Client> AddClient([FromBody] ClientCreateRequest clientCreateRequest)
        {
            try
            {
                _clientService.CreateClient(clientCreateRequest);
                return Ok();
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateClient(int id, [FromBody] ClientUpdateRequest clientUpdateRequest)
        {
            try
            {
                _clientService.UpdateClient(id, clientUpdateRequest);
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
        public IActionResult DeleteClient(int id)
        {
            try
            {
                _clientService.DeleteClient(id);
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
