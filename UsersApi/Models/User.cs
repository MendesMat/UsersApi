using Microsoft.AspNetCore.Identity;

namespace UsersApi.Model;

public class User : IdentityUser
{
    public User() : base() { }
}
