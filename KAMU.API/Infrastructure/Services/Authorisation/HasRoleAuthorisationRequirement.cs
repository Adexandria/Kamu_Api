using Microsoft.AspNetCore.Authorization;

namespace KAMU.API.Infrastructure.Services.Authorisation
{
    /// <summary>
    /// Describes the criteria that need to be satisfied for granting access
    /// </summary>
    public class HasRoleAuthorisationRequirement: IAuthorizationRequirement
    {
    }
}
