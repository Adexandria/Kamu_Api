using KAMU.API.Domain.Models;
using KAMU.API.Infrastructure.Repositories.Interfaces;
using NHibernate.Linq;
using ISession = NHibernate.ISession;

namespace KAMU.API.Infrastructure.Repositories
{
    /// <summary>
    /// Manages the activities of an organisation
    /// </summary>
    public class OrganisationRepository : Repository<Organisation>, IOrganisationRepository
    {
        /// <summary>
        /// A constructor
        /// </summary>
        /// <param name="session">Manages the transactions in a database</param>
        public OrganisationRepository(ISession session) : base(session)
        {
        }

        /// <summary>
        /// Fetches the organisation
        /// </summary>
        /// <param name="organisationId">Organisation id</param>
        /// <returns>An organisation</returns>
        public async Task<Organisation> FetchOrganisationAsync(Guid organisationId)
        {
            return await _session.Query<Organisation>().Where(s => s.Id == organisationId).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Checks if the organisation exists
        /// </summary>
        /// <returns>A boolean value</returns>
        public async Task<bool> IsExist()
        {
           return await _session.Query<Organisation>().AnyAsync();
        }
    }
}
