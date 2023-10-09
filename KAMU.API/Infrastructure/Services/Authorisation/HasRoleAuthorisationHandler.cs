using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace KAMU.API.Infrastructure.Services.Authorisation
{
    /// <summary>
    ///  Handles the authorisation requirement
    /// </summary>
    public class HasRoleAuthorisationHandler : AuthorizationHandler<HasRoleAuthorisationRequirement>
    {
        /// <summary>
        /// Verify if the user has access to the endpoint
        /// </summary>
        /// <param name="context">Contains authorisation information</param>
        /// <param name="requirement">Describes the criteria that need to be satisfied for granting access</param>
        /// <returns></returns>
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, HasRoleAuthorisationRequirement requirement)
        {
            var user = context.User;
            if (!user.Identity!.IsAuthenticated)
            {
                context.Fail();
                return;
            }

            var resource = context.Resource as DefaultHttpContext;
            var endpoint = resource.GetEndpoint();
            var attribute = endpoint.Metadata.GetMetadata<HasRoleAttribute>();

            var userRole = user.Claims.FirstOrDefault(s => s.Type == ClaimTypes.Role).Value;

            Enum.TryParse(typeof(Role),userRole, out object currentRole);

            if (currentRole == null)
            {
                context.Fail();
                return;
            }

            if (!attribute.Roles.Contains((Role)currentRole))
            {
                context.Fail();
                return;
            }
            

            context.Succeed(requirement);
        }
    }
}
