using KAMU.API.Infrastructure.Utilities;
using ISession = NHibernate.ISession;

namespace KAMU.API.Infrastructure.Services.Db
{
    /// <summary>
    /// Manages the data manipulation
    /// </summary>
    public class DbService : IDbService
    {
        /// <summary>
        /// A constructor
        /// </summary>
        /// <param name="session">Manages the transactions in the database</param>
        public DbService(ISession session)
        {
            _session = session;
        }

        /// <summary>
        /// Commit all activities to the database
        /// </summary>
        /// <returns>Action response</returns>
        public virtual async Task<ActionResponse> CommitAsync()
        {
            using var transaction = _session.BeginTransaction();
            try
            {
                await transaction.CommitAsync();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                return ActionResponse.Failed(ex.Message);
            }

            return ActionResponse.Successful();
        }

        /// <summary>
        /// Manages the transactions in the database
        /// </summary>
        private ISession _session;
    }
}
