using KAMU.API.Infrastructure.Extensions;
using KAMU.API.Infrastructure.Repositories.Interfaces;
using KAMU.API.Infrastructure.Utilities;

namespace KAMU.API.Infrastructure.Services.Security
{
    /// <summary>
    /// Manages the authentication
    /// </summary>
    public class AccessManager : IAccessManager
    {
        /// <summary>
        /// A constructor
        /// </summary>
        /// <param name="userRepository">Manages the authentication activities of all users</param>
        /// <param name="passwordManager">Manages password</param>
        public AccessManager(IUserRepository userRepository,IPasswordManager passwordManager)
        {
            _userRepository = userRepository;   
            _passwordManager = passwordManager;
        }
        /// <summary>
        /// Authenticates user using email and password
        /// </summary>
        /// <param name="email">User's email</param>
        /// <param name="password">User's password</param>
        /// <returns>Action response</returns>
        public ActionResponse<UserDetails> AuthenticateUser(string email, string password)
        {
          var currentUser = _userRepository.GetUserDetailsByEmail(email);
          if (currentUser == null)
              return ActionResponse<UserDetails>.Failed($"No user associated with {email}", StatusCodes.Status404NotFound);

         var isMatches = _passwordManager.VerifyPassword(currentUser.User.PasswordHash, password);
         return isMatches ? ActionResponse<UserDetails>.SuccessfulOperation(currentUser) : ActionResponse<UserDetails>.Failed("email or password is incorrect",StatusCodes.Status400BadRequest);
        }
        private readonly IPasswordManager _passwordManager;
        private readonly IUserRepository _userRepository;
    }
}
