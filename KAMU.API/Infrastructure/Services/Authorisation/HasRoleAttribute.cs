using Microsoft.AspNetCore.Authorization;

namespace KAMU.API.Infrastructure.Services.Authorisation
{
    /// <summary>
    /// A role attribute that manages policy
    /// </summary>
    public class HasRoleAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// A constructor
        /// </summary>
        public HasRoleAttribute():base(Policy)
        {

        }

        /// <summary>
        /// Specified roles
        /// </summary>
        public Role[] Roles { get; set; }

        /// <summary>
        /// Policy name
        /// </summary>
        public const string Policy = "HasRole";
    }
}
