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
        /// <param name="password">Plain password</param>
        /// <returns>Hashed password</returns>
        string GetHashedPassword(string password);

        /// <summary>
        /// Verifies provided password with hashed password
        /// </summary>
        /// <param name="hashedPassword">Hashed password</param>
        /// <param name="providedPassword">Plain password provided</param>
        /// <returns>Validation result</returns>
        bool VerifyPassword(string hashedPassword, string providedPassword);
    }
}
