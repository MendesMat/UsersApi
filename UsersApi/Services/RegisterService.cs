using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using UsersApi.Data.Dtos;
using UsersApi.Interfaces.Services;
using UsersApi.Model;

namespace UsersApi.Services;

public class RegisterService : IRegisterService
{
    private IMapper _mapper;
    private UserManager<User> _userManager;

    public RegisterService(IMapper mapper, 
                            UserManager<User> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task Register(CreateUserDto dto)
    {
        User user = _mapper.Map<User>(dto);
        IdentityResult result = await _userManager.CreateAsync(user, dto.Password);

        if (!result.Succeeded)
        {
            throw new ApplicationException("Falha ao cadastrar.");
        }
    }
}
