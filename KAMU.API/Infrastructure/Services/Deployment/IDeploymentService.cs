using KAMU.API.Infrastructure.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace KAMU.API.Infrastructure.Services.Deployment
{
    /// <summary>
    /// Manages the database seeding
    /// </summary>
    public interface IDeploymentService
    {
        /// <summary>
        /// Seeds the super admin into the database
        /// </summary>
        /// <returns>Action response</returns>
        Task<ActionResponse> CreateSuperAdmin();
    }
}
