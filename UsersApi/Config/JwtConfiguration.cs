namespace UsersApi.Config;

public class JwtConfiguration
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public bool ValidateIssuer { get; set; }
    public bool ValidateAudience { get; set; }
    public int ClockSkew { get; set; }
    public int ExpirationInHours { get; set; }
}
