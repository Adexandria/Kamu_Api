using KAMU.API.Domain.Models;
using KAMU.API.Infrastructure.Repositories.Interfaces;
using KAMU.API.Infrastructure.Services.Db;
using KAMU.API.Infrastructure.Utilities;

namespace KAMU.API.Infrastructure.Services.Organization
{
    /// <summary>
    /// Manages the organisation services
    /// </summary>
    public class OrganisationService : IOrganisationService
    {
        /// <summary>
        /// A constructor
        /// </summary>
        /// <param name="organisationRepository">Manages the activities of the organisation</param>
        /// <param name="superAdminRepository">Manages the activities of super admin</param>
        /// <param name="dbService">Manages the data manipulation</param>
        public OrganisationService(IOrganisationRepository organisationRepository, 
            ISuperAdminRepository superAdminRepository,
            IDbService dbService)
        {
            _organisationRepository = organisationRepository;
            _superAdminRepository = superAdminRepository;
            _dbService = dbService;
        }

        /// <summary>
        /// Creates the organisation
        /// </summary>
        /// <returns>Action response</returns>
        public async Task<ActionResponse<Guid>> CreateOrganisation()
        {
            try
            {
                var organisationExists = await _organisationRepository.IsExist();
                if (organisationExists)
                    return ActionResponse<Guid>.Failed("Organisation already exists", StatusCodes.Status400BadRequest);

                var superAdmin = await _superAdminRepository.GetDefaultSuperAdmin();
                if (superAdmin == null)
                    return ActionResponse<Guid>.Failed("Super admin can not be found", StatusCodes.Status404NotFound);

                var organisation = new Organisation();

                await _organisationRepository.AddAsync(organisation);

                superAdmin.Organisation = organisation;

                await _superAdminRepository.UpdateAsync(superAdmin);

                var commitStatus = await _dbService.CommitAsync();
                if (commitStatus.NotSuccessful)
                    return ActionResponse<Guid>.Failed("Failed to create organisation");

                return ActionResponse<Guid>.SuccessfulOperation(organisation.Id);
            }
            catch (Exception ex)
            {
                return ActionResponse<Guid>.Failed(ex.Message);
            }
        }
        private readonly ISuperAdminRepository _superAdminRepository;
        private readonly IOrganisationRepository _organisationRepository;
        private readonly IDbService _dbService;
    }
}
