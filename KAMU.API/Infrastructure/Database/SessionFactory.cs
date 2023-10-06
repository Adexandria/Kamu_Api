using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using KAMU.API.Infrastructure.Database.Mappings;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using ISession = NHibernate.ISession;

namespace KAMU.API.Infrastructure.Database
{
    public class SessionFactory : ISessionBuilder
    {
        public SessionFactory(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException(connectionString,"Connection string can not be null or empty");

            _sessionFactory = BuildSessionFactory(connectionString);
        }
        public ISession GetSession()
        {
           return _sessionFactory.OpenSession();
        }

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

        private readonly ISessionFactory _sessionFactory;
    }
}
