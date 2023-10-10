using KAMU.API.Domain.DTOs;
using KAMU.API.Infrastructure.Utilities;
using KAMU.API.Infrastructure.Services.Security;

namespace KAMU.API.Infrastructure.Services.Login
{
    /// <summary>
    /// Manages the login authentication
    /// </summary>
    public class LoginService : ILoginService
    {
        /// <summary>
        /// A constructor
        /// </summary>
        /// <param name="accessManager">Manages the authentication</param>
        /// <param name="tokenManager">Manages the token</param>
        public LoginService(IAccessManager accessManager, ITokenManager tokenManager)
        {
            _accessManager = accessManager;
            _tokenManager = tokenManager;
        }

        /// <summary>
        /// Signs in a user
        /// </summary>
        /// <param name="email">User's email</param>
        /// <param name="password">User's password</param>
        /// <returns>Action response</returns>
        public ActionResponse<LoginDetails> SignIn(string email, string password)
        {
            try
            {
                var authenticationResponse = _accessManager.AuthenticateUser(email, password);
                if (authenticationResponse.NotSuccessful)
                    return ActionResponse<LoginDetails>.Failed(StatusCodes.Status400BadRequest).AddErrors(authenticationResponse.Errors);

                var generatedAccessToken = _tokenManager.GenerateAccessToken(authenticationResponse.Data);

                var loginDetails = new LoginDetails
                {
                    Email = authenticationResponse.Data.User.Email,
                    FirstName = authenticationResponse.Data.User.FirstName,
                    LastName = authenticationResponse.Data.User.LastName,
                    OrganisationId = authenticationResponse.Data.User.Organisation == null ? new Guid() : authenticationResponse.Data.User.Organisation.Id,
                    Role = authenticationResponse.Data.Role.ToString(),
                    UserName = authenticationResponse.Data.User.UserName
                };
                return ActionTokenResponse<LoginDetails>.SuccessfulOperation(loginDetails, generatedAccessToken);
            }
            catch (Exception ex)
            {
                return ActionResponse<LoginDetails>.Failed(ex.Message);
            }
           
        }
        private ITokenManager _tokenManager;
        private readonly IAccessManager _accessManager;
    }
}
