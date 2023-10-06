using Microsoft.AspNetCore.Identity;

namespace KAMU.API.Infrastructure.Services.Security
{
    /// <summary>
    /// Manages Password
    /// </summary>
    public interface IPasswordManager
    {
        /// <summary>
        /// Hashed password
        /// </summary>
        /// <typeparam name="T">Identity user</typeparam>
        /// <param name="password">Plain password</param>
        /// <returns>Hashed password</returns>
        string GetHashedPassword<T>(string password) where T: IdentityUser;

        /// <summary>
        /// Verifies provided password with hashed password
        /// </summary>
        /// <typeparam name="T">Identity user</typeparam>
        /// <param name="hashedPassword">Hashed password</param>
        /// <param name="providedPassword">Plain password provided</param>
        /// <returns>Validation result</returns>
        bool VerifyPassword<T>(string hashedPassword, string providedPassword) where T : IdentityUser;
    }
}
