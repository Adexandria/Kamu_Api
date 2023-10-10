using KAMU.API.Domain.Models;
using KAMU.API.Infrastructure.Repositories.Interfaces;
using NHibernate.Linq;

namespace KAMU.API.Infrastructure.Repositories
{
    /// <summary>
    /// Manages the activities of super admin
    /// </summary>
    public class SuperAdminRepository : Repository<SuperAdmin>, ISuperAdminRepository
    {
        /// <summary>
        /// A constructor
        /// </summary>
        /// <param name="session">Manages the transactions in a database</param>
        public SuperAdminRepository(NHibernate.ISession session) : base(session)
        {
        }

        /// <summary>
        /// Gets the default super admin
        /// </summary>
        /// <returns>Super admin</returns>
        public async Task<SuperAdmin> GetDefaultSuperAdmin()
        {
            return await _session.Query<SuperAdmin>().FirstOrDefaultAsync();
        }
    }
}
