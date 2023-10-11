using KAMU.API.Infrastructure.Utilities;

namespace KAMU.API.Infrastructure.Services.Db
{
    /// <summary>
    /// Manages the data manipulation
    /// </summary>
    public interface IDbService
    {
        /// <summary>
        /// Commit all activities to the database
        /// </summary>
        /// <returns>Action response</returns>
        Task<ActionResponse> CommitAsync();
    }
}
