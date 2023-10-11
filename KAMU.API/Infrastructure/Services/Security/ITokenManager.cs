using KAMU.API.Infrastructure.Utilities;

namespace KAMU.API.Infrastructure.Services.Security
{
    /// <summary>
    /// Manages token
    /// </summary>
    public interface ITokenManager
    {
        /// <summary>
        /// Generates access token
        /// </summary>
        /// <param name="userDetails">User's details</param>
        /// <returns>access token</returns>
        string GenerateAccessToken(UserDetails userDetails);
    }
}
