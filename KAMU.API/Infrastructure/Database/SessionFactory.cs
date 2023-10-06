using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using KAMU.API.Infrastructure.Database.Mappings;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using ISession = NHibernate.ISession;

namespace KAMU.API.Infrastructure.Database
{
    /// <summary>
    /// Manages the sessions
    /// </summary>
    public class SessionFactory : ISessionBuilder
    {
        /// <summary>
        /// A Constructor.
        /// 
        /// It sets up the session configuration.
        /// </summary>
        /// <param name="connectionString">A connection string</param>
        /// <exception cref="ArgumentNullException">If the connection string is empty or null</exception>
        public SessionFactory(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException(connectionString,"Connection string can not be null or empty");

            _sessionFactory = BuildSessionFactory(connectionString);
        }

        /// <summary>
        /// Builds the session factory
        /// </summary>
        /// <returns>Session</returns>
        public ISession GetSession()
        {
           return _sessionFactory.OpenSession();
        }

        /// <summary>
        /// Builds the session configuration
        /// </summary>
        /// <param name="connectionString">A connection string</param>
        /// <returns>ISession Factory</returns>
        private ISessionFactory BuildSessionFactory(string connectionString)
        {
            FluentConfiguration configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString)
                .ShowSql()
                .FormatSql())
                .Mappings(m => m.FluentMappings.AddFromAssembly(typeof(BaseEntityMapping).Assembly))
                .ExposeConfiguration(cfg =>
                {
                    new SchemaUpdate(cfg).Execute(true, true);
                });
            return configuration.BuildSessionFactory();
        }

        /// <summary>
        /// Manages the session configuration 
        /// </summary>
        private readonly ISessionFactory _sessionFactory;
    }
}
