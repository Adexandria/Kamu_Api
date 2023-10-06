using Microsoft.AspNetCore.Authorization;

namespace KAMU.API.Infrastructure.Services.Authorisation
{
    public class HasRoleAttribute : AuthorizeAttribute
    {
        public HasRoleAttribute():base(Policy)
        {

        }
        public Role[] Roles { get; set; }

        public const string Policy = "HasRole";
    }
}
