using Microsoft.AspNetCore.Identity;

namespace KAMU.API.Infrastructure.Services.Security
{
    /// <summary>
    /// Manages Password
    /// </summary>
    public class PasswordManager : IPasswordManager
    {
        /// <summary>
        /// Hashed password
        /// </summary>
        /// <typeparam name="T">Identity user</typeparam>
        /// <param name="password">Plain password</param>
        /// <returns>Hashed password</returns>
        public string GetHashedPassword<T>(string password) where T : IdentityUser
        {
            return new PasswordHasher<T>().HashPassword(null, password);
        }

        /// <summary>
        /// Verifies provided password with hashed password
        /// </summary>
        /// <typeparam name="T">Identity user</typeparam>
        /// <param name="hashedPassword">Hashed password</param>
        /// <param name="providedPassword">Plain password provided</param>
        /// <returns>Validation result</returns>
        public bool VerifyPassword<T>(string hashedPassword, string providedPassword) where T : IdentityUser
        {
            return new PasswordHasher<T>().VerifyHashedPassword(null, hashedPassword, providedPassword) 
                == PasswordVerificationResult.Success;
        }
    }
}
