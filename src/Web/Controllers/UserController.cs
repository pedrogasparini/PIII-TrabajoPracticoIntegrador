using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private List<User> _users; // Simulación de una lista de usuarios (en un escenario real usarías una base de datos)

    public UserController()
    {
        // Inicialización de usuarios de ejemplo
        _users = new List<User>
        {
            new Admin { UserId = 1, Username = "admin", Password = "admin123", Role = "admin" },
            new SysAdmin { UserId = 2, Username = "sysadmin", Password = "sysadmin123", Role = "sysadmin" },
            new Client { UserId = 3, Username = "client", Password = "client123", Role = "client", Name = "John Doe", Address = "123 Main St", Phone = "555-1234" }
        };
    }

    // Endpoint para autenticar usuarios
    [HttpPost("authenticate")]
    public IActionResult Authenticate([FromBody] User loginUser)
    {
        var user = _users.SingleOrDefault(u => u.Username == loginUser.Username && u.Password == loginUser.Password);

        if (user == null)
            return BadRequest(new { message = "Username or password is incorrect" });

        return Ok(user);
    }
}

