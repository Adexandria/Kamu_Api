using KAMU.API.Infrastructure.Database;
using KAMU.API.Infrastructure.Services.Security;
using KAMU.API.Infrastructure.Utilities;

namespace KAMU.API.Infrastructure.Extensions
{
    /// <summary>
    /// A service to register all dependencies in the application
    /// </summary>
    public static class DependencyService
    {
        /// <summary>
        /// Set up dependencies using the service collection and application settings
        /// </summary>
        /// <param name="serviceCollection">Specifies the contract for a collection of service descriptors</param>
        /// <param name="appSettings">Manages application settings</param>
        public static void SetUpDependencies(this IServiceCollection serviceCollection, ApplicationSettings appSettings)
        {
            serviceCollection.AddSingleton((_) => new SessionFactory(appSettings.ConnectionString).GetSession());
            serviceCollection.AddScoped<IPasswordManager, PasswordManager>();
        }
    }
}
