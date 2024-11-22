using Microsoft.AspNetCore.Authentication.Cookies;

namespace UsersApi.Config;

public static class CookieConfiguration
{
    public static void ConfigureCookies(this CookieAuthenticationOptions options)
    {
        // Nome do cookie
        options.Cookie.Name = "UsersApiAuthCookie";

        // Cookies devem ser acessados apenas via HTTP (não JavaScript)
        options.Cookie.HttpOnly = true;

        // Tempo de expiração do cookie persistente
        options.ExpireTimeSpan = TimeSpan.FromDays(7);

        // Renovação automática do cookie próximo da expiração
        options.SlidingExpiration = true;

        // Configuração para tornar o cookie essencial (não bloqueado por cookies restritos)
        options.Cookie.IsEssential = true;

        // Política de SameSite
        options.Cookie.SameSite = SameSiteMode.Lax;
    }
}
