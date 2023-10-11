using KAMU.API.Domain.DTOs;
using KAMU.API.Infrastructure.Utilities;

namespace KAMU.API.Infrastructure.Services.Login
{
    /// <summary>
    /// Manages the login authentication
    /// </summary>
    public interface ILoginService
    {
        /// <summary>
        /// Signs in a user
        /// </summary>
        /// <param name="email">User's email</param>
        /// <param name="password">User's password</param>
        /// <returns>Action response</returns>
        ActionResponse<LoginDetails> SignIn(string email, string password);
    }
}
