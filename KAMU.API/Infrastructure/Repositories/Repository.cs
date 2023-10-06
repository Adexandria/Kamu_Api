using KAMU.API.Infrastructure.Extensions;
using ISession = NHibernate.ISession;
namespace KAMU.API.Infrastructure.Repositories
{
    public class Repository
    {
        public Repository(ISession session)
        {
            _session = session;
        }

        public async Task<ActionResponseResult> CommitAsync()
        {
            using var transaction = _session.BeginTransaction();
            try
            {
                await transaction.CommitAsync();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                return ActionResponseResult.Failed(ex.InnerException?.Message);
            }

            return ActionResponseResult.Successful();
        }


        protected readonly ISession _session;
    }
}
