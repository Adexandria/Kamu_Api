using KAMU.API.Domain.DTOs;
using KAMU.API.Domain.Models;
using KAMU.API.Infrastructure.Extensions;
using KAMU.API.Infrastructure.Repositories.Interfaces;
using KAMU.API.Infrastructure.Services.Authorisation;
using KAMU.API.Infrastructure.Services.Db;
using KAMU.API.Infrastructure.Services.Security;
using KAMU.API.Infrastructure.Utilities;

namespace KAMU.API.Infrastructure.Services.User
{
    /// <summary>
    /// Manages the services of all user types
    /// </summary>
    public class UserService : IUserService
    {
        /// <summary>
        /// A constructor
        /// </summary>
        /// <param name="studentRepository">Manages the activities of the student</param>
        /// <param name="userInstructorRepository">Manages the activities of an instructor</param>
        /// <param name="userRepository">Manages the authentication activities of all users</param>
        /// <param name="superAdminRepository">Manages the activities of super admin</param>
        /// <param name="passwordManager">Manages password</param>
        /// <param name="organisationRepository">Manages the activities of an organisation</param>
        /// <param name="dbService">Manages the data manipulation</param>
        public UserService(IStudentRepository studentRepository, 
            IUserInstructorRepository userInstructorRepository,
            IUserRepository userRepository,
            ISuperAdminRepository superAdminRepository,
            IPasswordManager passwordManager,
            IOrganisationRepository organisationRepository,
            IDbService dbService)
        {
            _studentRepository = studentRepository;
            _userInstructorRepository = userInstructorRepository;
            _userRepository = userRepository;
            _superAdminRepository = superAdminRepository;
            _dbService = dbService;
            _passwordManager = passwordManager;
            _organisationRepository = organisationRepository;
        }

        /// <summary>
        /// Creates a user
        /// </summary>
        /// <param name="newUser">Model to persist a new user</param>
        /// <param name="organisationId">Organisation id</param>
        /// <param name="role">Role of the user</param>
        /// <returns>Action response</returns>
        public async Task<ActionResponse> CreateUser(SignupDTO newUser, Guid organisationId, Role role)
        {
            try
            {
                var userExists = _userRepository.IsEmailExists(newUser.Email);
                if (userExists)
                    return ActionResponse.Failed("Email already exists", StatusCodes.Status400BadRequest);


                var currentOrganisation = await _organisationRepository.FetchOrganisationAsync(organisationId);
                if (currentOrganisation == null)
                    return ActionResponse.Failed("Organisation does not exist", StatusCodes.Status404NotFound);

                var hashedPassword = _passwordManager.GetHashedPassword(newUser.Password);

                var person = new Person()
                {
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    Email = newUser.Email,
                    PasswordHash = hashedPassword,
                    UserName = newUser.UserName,
                    Organisation = currentOrganisation
                };


                if (Role.SuperAdmin == role)
                {
                    await _superAdminRepository.AddAsync(person.ConvertTo<SuperAdmin>());
                }
                else if (Role.Instructor == role)
                {
                    await _userInstructorRepository.AddAsync(person.ConvertTo<Instructor>());
                }
                else
                {
                    await _studentRepository.AddAsync(person.ConvertTo<Student>());
                }

                var commitStatus =  await _dbService.CommitAsync();
                if(commitStatus.NotSuccessful)
                    return ActionResponse.Failed("Failed to create user");

                return ActionResponse.Successful();
            }
            catch (Exception ex)
            {

                return ActionResponse.Failed(ex.Message);
            }
        }

        private readonly IStudentRepository _studentRepository;
        private readonly IUserInstructorRepository _userInstructorRepository;
        private readonly IUserRepository _userRepository;
        private readonly ISuperAdminRepository _superAdminRepository;
        private readonly IDbService _dbService;
        private readonly IPasswordManager _passwordManager;
        private readonly IOrganisationRepository _organisationRepository;
    }
}
