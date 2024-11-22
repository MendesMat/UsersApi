using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace UsersApi.Authorization;

public class EmailDomainHandler : AuthorizationHandler<EmailDomainRequirement>
{
    private readonly ILogger<EmailDomainHandler> _logger;

    public EmailDomainHandler(ILogger<EmailDomainHandler> logger)
    {
        _logger = logger;
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, 
                                                    EmailDomainRequirement requirement)
    {
        var emailClaim = context.User.FindFirst(ClaimTypes.Email)?.Value;

        if (IsValidDomain(emailClaim, requirement.allowedDomain))
        {
            _logger.LogInformation("Usuário autorizado.");
            context.Succeed(requirement);
        }
        else
        {
            _logger.LogWarning("Usuário não autorizado.");
            context.Fail();    
        }

        return Task.CompletedTask;
    }

    bool IsValidDomain(string emailClaim, string allowedDomain)
    {
        return !string.IsNullOrEmpty(allowedDomain)
            && emailClaim.EndsWith($"{allowedDomain}");
    }
}
