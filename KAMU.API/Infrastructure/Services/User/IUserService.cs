using KAMU.API.Domain.DTOs;
using KAMU.API.Domain.Models;
using KAMU.API.Infrastructure.Services.Authorisation;
using KAMU.API.Infrastructure.Utilities;

namespace KAMU.API.Infrastructure.Services.User
{
    /// <summary>
    /// Manages the services of all user types
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Creates a user
        /// </summary>
        /// <param name="newUser">Model to persist a new user</param>
        /// <param name="organisationId">Organisation id</param>
        /// <param name="role">Role of the user</param>
        /// <returns>Action response</returns>
        Task<ActionResponse> CreateUser(SignupDTO newUser, Guid organisationId, Role role);
    }
}
