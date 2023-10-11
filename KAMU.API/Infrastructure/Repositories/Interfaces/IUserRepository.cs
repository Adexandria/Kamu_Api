using KAMU.API.Domain.Models;
using KAMU.API.Infrastructure.Utilities;

namespace KAMU.API.Infrastructure.Repositories.Interfaces
{
    /// <summary>
    /// Manages the authentication activities of all users
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Gets the user details by email
        /// </summary>
        /// <param name="email">User's email</param>
        /// <returns>User details</returns>
        UserDetails GetUserDetailsByEmail(string email);

        /// <summary>
        /// Checks if the email exists in the super admin, student and instructor tables
        /// </summary>
        /// <param name="email">Email of user</param>
        /// <returns>A boolean value</returns>
        bool IsEmailExists(string email);
      
    }
}