using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace KAMU.API.Infrastructure.Services.Authorisation
{
    public class HasRoleAuthorisationHandler : AuthorizationHandler<HasRoleAuthorisationRequirement>
    {
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
