using KAMU.API.Domain.Models;

namespace KAMU.API.Infrastructure.Repositories.Interfaces
{
    /// <summary>
    /// Manages the activities of an organisation
    /// </summary>
    public interface IOrganisationRepository : IRepository<Organisation>
    {
        /// <summary>
        /// Fetches the organisation
        /// </summary>
        /// <param name="organisationId">Organisation id</param>
        /// <returns>An organisation</returns>
        Task<Organisation> FetchOrganisationAsync(Guid organisationId);

        /// <summary>
        /// Checks if the organisation exists
        /// </summary>
        /// <returns>A boolean value</returns>
        Task<bool> IsExist();
    }
}
