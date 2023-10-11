using KAMU.API.Domain.Models;

namespace KAMU.API.Infrastructure.Repositories.Interfaces
{
    /// <summary>
    /// Manages the activities of super admin
    /// </summary>
    public interface ISuperAdminRepository : IRepository<SuperAdmin>
    {
        /// <summary>
        /// Gets the default super admin
        /// </summary>
        /// <returns>Super admin</returns>
        Task<SuperAdmin> GetDefaultSuperAdmin();
    }
}
