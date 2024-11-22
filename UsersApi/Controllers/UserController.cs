using Microsoft.AspNetCore.Mvc;
using UsersApi.Data.Dtos;
using UsersApi.Interfaces.Services;

namespace UsersApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class UserController : ControllerBase
{
    private IRegisterService _registerService;
    private ILoginService _loginService;

    public UserController(IRegisterService registerService, 
                        ILoginService loginService)
    {
        _registerService = registerService;
        _loginService = loginService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> AddUser(CreateUserDto dto)
    {
        await _registerService.Register(dto);
        return Ok("Usuario Cadastrado.");
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginUserAsync(LoginUserDto dto)
    {
        var token = await _loginService.Login(dto);
        return Ok(token);
    }
}
