using Microsoft.AspNetCore.Authorization;

namespace UsersApi.Authorization;

public class EmailDomainRequirement : IAuthorizationRequirement
{
    public string allowedDomain { get; }

    public EmailDomainRequirement(string allowedDomain)
    {
        this.allowedDomain = allowedDomain;
    }
}
