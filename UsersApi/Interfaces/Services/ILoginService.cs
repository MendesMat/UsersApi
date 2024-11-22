using UsersApi.Data.Dtos;

namespace UsersApi.Interfaces.Services;

public interface ILoginService
{
    Task<string> Login(LoginUserDto dto);
}
