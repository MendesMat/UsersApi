using Microsoft.AspNetCore.Identity;

namespace UsersApi.Config;

public static class IdentityConfiguration
{
    public static IdentityOptions ConfigureIdentityOptions(this IdentityOptions options)
    {
        // Configurações de usuário
        options.User.RequireUniqueEmail = false;

        // Configurações para senha
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 6;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;

        // Configurações de lockout (bloqueio)
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.Zero;
        options.Lockout.MaxFailedAccessAttempts = int.MaxValue;
        options.Lockout.AllowedForNewUsers = true;

        return options;
    }
}
