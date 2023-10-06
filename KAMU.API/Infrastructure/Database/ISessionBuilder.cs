using ISession = NHibernate.ISession;

namespace KAMU.API.Infrastructure.Database
{
    /// <summary>
    /// Manages the sessions
    /// </summary>
    public interface ISessionBuilder
    {
        /// <summary>
        /// Builds the session factory
        /// </summary>
        /// <returns>Session</returns>
        ISession GetSession();
    }
}
