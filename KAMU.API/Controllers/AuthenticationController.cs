using KAMU.API.Domain.DTOs;
using KAMU.API.Infrastructure.Extensions;
using KAMU.API.Infrastructure.Services.Authorisation;
using KAMU.API.Infrastructure.Services.Login;
using KAMU.API.Infrastructure.Services.Security;
using KAMU.API.Infrastructure.Services.User;
using KAMU.API.Infrastructure.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KAMU.API.Controllers
{
    /// <summary>
    /// Manages authentication
    /// </summary>
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        /// <summary>
        /// A constructor
        /// </summary>
        /// <param name="loginService">Manages the login authentication</param>
        /// <param name="userService">Manages the services of all user types</param>
        /// <param name="userContext">Manages the user details gotten from the claims</param>
        /// <param name="validation">Validates request properties</param>
        public AuthenticationController(ILoginService loginService,
            IUserService userService,
            IUserContext userContext, Validation validation) : base(userContext,validation)
        {
            _loginService = loginService;
            _userService = userService;
        }

        /// <summary>
        /// Logins a user
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///                 POST authentication/sign-in
        ///                 {
        ///                     "email": "string@gmail.com",
        ///                     "password": "string123"
        ///                 }
        /// 
        /// </remarks> 
        /// <param name="loginDto">A model to log in users</param>
        /// <returns>Action result</returns>
        [AllowAnonymous]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ActionResponse<LoginDetails>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ActionResponse<LoginDetails>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ActionResponse<LoginDetails>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ActionResponse<LoginDetails>), StatusCodes.Status500InternalServerError)]
        [HttpPost("sign-in")]
        public IActionResult Login(LoginDTO loginDto)
        {
            var validationResponse = Validator.IsValidEmail(loginDto.Email, "Invalid email")
                .IsValidText(loginDto.Password, "Invalid password").Result;

            if (validationResponse.NotSuccessful)
                return validationResponse.ResponseResult();

            var response = _loginService.SignIn(loginDto.Email, loginDto.Password);
            return response.ResponseResult();
        }

        /// <summary>
        /// Signs up students in an organisation
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///                 POST authentication/sign-up/student
        ///                 {        
        ///                     "firstName": "string",
        ///                     "lastName": "string",
        ///                     "email": "string@gmail.com",
        ///                     "password": "string",
        ///                     "userName": "string",
        ///                     "organisationId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
        ///                 }
        /// </remarks>
        /// <param name="signUpDTO">A model to sign up users</param>
        /// <returns>Action result</returns>
        [AllowAnonymous]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ActionResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ActionResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ActionResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ActionResponse), StatusCodes.Status500InternalServerError)]
        [HttpPost("sign-up/student")]
        public async Task<IActionResult> SignStudent(SignupDTO signUpDTO)
        {
            var validationResponse = Validator
                .IsValidText(signUpDTO.FirstName, "Invalid first name")
                .IsValidText(signUpDTO.LastName, "Invalid last name")
                .IsValidText(signUpDTO.UserName, "Invalid UserName")
                 .IsValidText(signUpDTO.Password,"Invalid password")
                 .IsValidEmail(signUpDTO.Email,"Invalid email")
                 .IsValidGuid(signUpDTO.OrganisationId, "Invalid organisation").Result;

            if (validationResponse.NotSuccessful)
                return validationResponse.ResponseResult();

            var response = await _userService.CreateUser(signUpDTO, signUpDTO.OrganisationId, Role.Student);
            return response.ResponseResult();
        }

        /// <summary>
        /// Signs up instructors in an organisation
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///               POST authentication/sign-up/instructor
        ///                 {        
        ///                     "firstName": "string",
        ///                     "lastName": "string",
        ///                     "email": "string@gmail.com",
        ///                     "password": "string",
        ///                     "userName": "string",
        ///                     "organisationId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
        ///                 }               
        /// 
        /// </remarks> 
        /// <param name="signUpDTO">A model to sign up users</param>
        /// <returns>Action result</returns>
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ActionResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ActionResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ActionResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ActionResponse), StatusCodes.Status500InternalServerError)]
        [HasRole(Role.SuperAdmin)]
        [HttpPost("sign-up/instructor")]
        public async Task<IActionResult> SignUpInstructor(SignupDTO signUpDTO)
        {
            var validationResponse = Validator
                .IsValidText(signUpDTO.FirstName, "Invalid first name")
                .IsValidText(signUpDTO.LastName, "Invalid last name")
                .IsValidText(signUpDTO.UserName, "Invalid UserName")
                 .IsValidText(signUpDTO.Password, "Invalid password")
                 .IsValidEmail(signUpDTO.Email, "Invalid email")
                 .IsValidGuid(signUpDTO.OrganisationId,"Invalid organisation").Result;

            if (validationResponse.NotSuccessful)
                return validationResponse.ResponseResult();

            var response = await _userService.CreateUser(signUpDTO, signUpDTO.OrganisationId, Role.Instructor);
            return response.ResponseResult();
        }

        private readonly IUserService _userService;
        private readonly ILoginService _loginService;
    }
}
