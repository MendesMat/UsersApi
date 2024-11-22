using UsersApi.Model;

namespace UsersApi.Interfaces.Services;

public interface ITokenService
{
    string GenerateToken(User user);
}
