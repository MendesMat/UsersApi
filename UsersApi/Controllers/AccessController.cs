using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UsersApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class AccessController : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = "Employee")]
    public IActionResult Get()
    {
        return Ok("Acesso permitido.");
    }
}
