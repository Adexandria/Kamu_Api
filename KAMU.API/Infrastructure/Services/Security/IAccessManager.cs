using KAMU.API.Infrastructure.Extensions;
using KAMU.API.Infrastructure.Utilities;

namespace KAMU.API.Infrastructure.Services.Security
{
    /// <summary>
    /// Manages the authentication
    /// </summary>
    public interface IAccessManager
    {
        /// <summary>
        /// Authenticates user using email and password
        /// </summary>
        /// <param name="email">User's email</param>
        /// <param name="password">User's password</param>
        /// <returns>Action response</returns>
        ActionResponse<UserDetails> AuthenticateUser(string email, string password);
    }
}
