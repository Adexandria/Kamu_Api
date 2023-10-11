using KAMU.API.Domain.Models;
using KAMU.API.Infrastructure.Repositories.Interfaces;
using KAMU.API.Infrastructure.Services.Db;
using KAMU.API.Infrastructure.Services.Security;
using KAMU.API.Infrastructure.Utilities;

namespace KAMU.API.Infrastructure.Services.Deployment
{
    /// <summary>
    /// Manages the database seeding
    /// </summary>
    public class DeploymentService : IDeploymentService
    {
        /// <summary>
        /// A constructor
        /// </summary>
        /// <param name="deploymentConfiguration">Manages the configuration secrets to seed to the database</param>
        /// <param name="userRepository"> Manages the authentication activities of all users</param>
        /// <param name="superAdminRepository">Manages the activities of super admin</param>
        /// <param name="passwordManager">Manages password</param>
        /// <param name="dbService">Manages the data manipulation</param>
        public DeploymentService(IDeploymentConfiguration deploymentConfiguration,
            IUserRepository userRepository,
            ISuperAdminRepository superAdminRepository,
            IPasswordManager passwordManager, 
            IDbService dbService)
        {
            _deploymentConfiguration = deploymentConfiguration;
            _userRepository = userRepository;
            _superAdminRepository = superAdminRepository;
            _passwordManager = passwordManager;
            _dbService = dbService;
        }

        /// <summary>
        /// Seeds the super admin into the database
        /// </summary>
        /// <returns>Action response</returns>
        public async Task<ActionResponse> CreateSuperAdmin()
        {
            var userExists = _userRepository.IsEmailExists(_deploymentConfiguration.Email);
            if (userExists)
                return ActionResponse.Failed("Email already exists",StatusCodes.Status400BadRequest);

            var hashedPassword = _passwordManager.GetHashedPassword(_deploymentConfiguration.Password);

            var superadmin = new SuperAdmin()
            {
                FirstName = _deploymentConfiguration.FirstName,
                LastName = _deploymentConfiguration.LastName,
                Email = _deploymentConfiguration.Email,
                PasswordHash = hashedPassword,
                UserName = _deploymentConfiguration.UserName,
            };

            await _superAdminRepository.AddAsync(superadmin);

            var commitStatus = await _dbService.CommitAsync();
            if (commitStatus.NotSuccessful)
                return ActionResponse.Failed("Failed to create super admin");

            return ActionResponse.Successful();
        }
        private readonly IUserRepository _userRepository;
        private readonly IDeploymentConfiguration _deploymentConfiguration;
        private readonly ISuperAdminRepository _superAdminRepository;
        private readonly IPasswordManager _passwordManager;
        private readonly IDbService _dbService;
    }
}
