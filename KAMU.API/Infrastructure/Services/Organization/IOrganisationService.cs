using KAMU.API.Infrastructure.Utilities;

namespace KAMU.API.Infrastructure.Services.Organization
{
    /// <summary>
    /// Manages the organisation services
    /// </summary>
    public interface IOrganisationService
    {
        /// <summary>
        /// Creates the organisation
        /// </summary>
        /// <returns>Action response</returns>
        Task<ActionResponse<Guid>> CreateOrganisation();
    }
}
