using KAMU.API.Infrastructure.Utilities;

namespace KAMU.API.Infrastructure.Extensions
{
    /// <summary>
    /// Extracts the application settings from the appsettings or user secret
    /// </summary>
    public static class ConfigurationExtractor
    {
        /// <summary>
        /// Extracts connection strings
        /// </summary>
        /// <param name="configuration">Represents a set of key/value application configuration properties.</param>
        /// <returns>Connection string</returns>
        private static string ExtractConnectionString(IConfiguration configuration)
        {
            return configuration.GetConnectionString("KamuDB");
        }

        /// <summary>
        ///  Gets the application settings
        /// </summary>
        /// <param name="configuration">Represents a set of key/value application configuration properties.</param>
        /// <returns>Application settings</returns>
        public static ApplicationSettings ExtractAppConfigurations(this IConfiguration configuration)
        {
            return new ApplicationSettings
            {
                ConnectionString = ExtractConnectionString(configuration)
            };
        }
    }
}
