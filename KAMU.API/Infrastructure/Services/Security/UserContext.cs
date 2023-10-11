using System.IdentityModel.Tokens.Jwt;

namespace KAMU.API.Infrastructure.Services.Security
{
    /// <summary>
    /// Manages the user details gotten from the claims
    /// </summary>
    public class UserContext : IUserContext
    {
        /// <summary>
        /// A constructor
        /// </summary>
        /// <param name="httpContextAccessor">Provides information about the authenticated user and response</param>
        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            var httpContext = httpContextAccessor?.HttpContext;

            Guid.TryParse(httpContext.User?.Claims.FirstOrDefault(s=> s.Type == JwtRegisteredClaimNames.NameId)?.Value, out  Guid userId);

            Guid.TryParse(httpContext.User?.Claims.FirstOrDefault(s => s.Type == "orgId")?.Value, out Guid orgId);

            Email = httpContext.User?.Claims.FirstOrDefault(s => s.Type == JwtRegisteredClaimNames.Email)?.Value;

            CurrentUserId = userId;
            OrganisationId = orgId;
        }

        /// <summary>
        /// User's id
        /// </summary>
        public Guid CurrentUserId { get; set; }

        /// <summary>
        /// User's organisation id
        /// </summary>
        public Guid OrganisationId { get; set; }

        /// <summary>
        /// User's email
        /// </summary>
        public string Email { get; set; }
    }
}
