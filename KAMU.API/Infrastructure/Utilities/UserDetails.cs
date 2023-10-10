using KAMU.API.Domain.Models;
using KAMU.API.Infrastructure.Services.Authorisation;

namespace KAMU.API.Infrastructure.Utilities
{
    /// <summary>
    /// Handles the details of the user
    /// </summary>
    public class UserDetails
    {
        /// <summary>
        /// A constructor
        /// </summary>
        /// <param name="_user">Handles the user</param>
        /// <param name="_role">Handles the role of the user</param>
        public UserDetails(Person _user, Role _role)
        {
            User = _user;
            Role = _role;
        }
        /// <summary>
        /// Handles the user
        /// </summary>
        public Person User { get; set; }

        /// <summary>
        /// Handles the role of the user
        /// </summary>
        public Role Role { get; set; }
    }
}
