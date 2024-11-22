using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsersApi.Config;
using UsersApi.Interfaces.Services;
using UsersApi.Model;

namespace UsersApi.Services;

public class TokenService : ITokenService
{
    private IConfiguration _configuration;
    private readonly JwtConfiguration _jwtConfiguration;

    public TokenService(IOptions<JwtConfiguration> jwtConfiguration, 
                        IConfiguration configuration)
    {
        _jwtConfiguration = jwtConfiguration.Value;
        _configuration = configuration;
    }

    public string GenerateToken(User user)
    {
        Claim[] claims =
        {
            new("id", user.Id),
            new("username", user.UserName),
            new("email", user.Email)
        };

        var key = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(_configuration["SymmetricSecurityKey"]));

        var signingCredentials = new SigningCredentials(key,
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
                issuer: "UsersApi",
                audience: "UsersApiClient",
                expires: DateTime.Now.AddHours(1),
                claims: claims,
                signingCredentials: signingCredentials
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return tokenString;
    }
}
