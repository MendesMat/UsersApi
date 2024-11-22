using UsersApi.Data.Dtos;

namespace UsersApi.Interfaces.Services;

public interface IRegisterService
{
    Task Register(CreateUserDto dto);
}
