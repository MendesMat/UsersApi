using Microsoft.AspNetCore.Identity;
using UsersApi.Data.Dtos;
using UsersApi.Interfaces.Services;
using UsersApi.Model;

namespace UsersApi.Services;

public class LoginService : ILoginService
{
    private SignInManager<User> _signInManager;
    private ITokenService _tokenService;

    public LoginService(SignInManager<User> signInManager,
                        ITokenService tokenService)
    {
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task<string> Login(LoginUserDto dto)
    {
        SignInResult result = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password,
            true, false);

        if (!result.Succeeded)
        {
            throw new ApplicationException("Login não autenticado.");
        }

        var user = await _signInManager.UserManager.FindByNameAsync(dto.Username);
        var token = _tokenService.GenerateToken(user);

        return token;
    }
}
