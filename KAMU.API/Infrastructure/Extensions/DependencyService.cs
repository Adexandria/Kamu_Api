using KAMU.API.Infrastructure.Database;
using KAMU.API.Infrastructure.Services.Authorisation;
using KAMU.API.Infrastructure.Services.Security;
using KAMU.API.Infrastructure.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace KAMU.API.Infrastructure.Extensions
{
    /// <summary>
    /// A service to register all dependencies in the application
    /// </summary>
    public static class DependencyService
    {
        /// <summary>
        /// Sets up dependencies using the service collection and application settings
        /// </summary>
        /// <param name="serviceCollection">Specifies the contract for a collection of service descriptors</param>
        /// <param name="appSettings">Manages application settings</param>
        public static void SetUpDependencies(this IServiceCollection serviceCollection, ApplicationSettings appSettings)
        {
            serviceCollection.AddSingleton((_) => new SessionFactory(appSettings.ConnectionString).GetSession());
            serviceCollection.AddScoped<IPasswordManager, PasswordManager>();
        }

        /// <summary>
        /// Sets up policy configuration
        /// </summary>
        /// <param name="serviceCollection"></param>
        public static void SetUpPolicy(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAuthorization(o =>
            {
                o.AddPolicy(HasRoleAttribute.Policy, p =>
                {
                    p.Requirements.Add(new HasRoleAuthorisationRequirement());
                    p.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
                });
            });
        }
    }
}
