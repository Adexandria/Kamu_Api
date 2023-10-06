using ISession = NHibernate.ISession;
using KAMU.API.Infrastructure.Database;
using KAMU.API.Infrastructure.Utilities;

namespace KAMU.API.Infrastructure.Services
{
    public static class DependencyService
    {
        public static void SetUpDependencies(this IServiceCollection serviceCollection, ApplicationSettings appSettings)
        {
            serviceCollection.AddSingleton<ISession>((_) => new SessionFactory(appSettings.ConnectionString).GetSession());
        }
    }
}
