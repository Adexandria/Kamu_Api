using ISession = NHibernate.ISession;

namespace KAMU.API.Infrastructure.Database
{
    public interface ISessionBuilder
    {
        ISession GetSession();
    }
}
