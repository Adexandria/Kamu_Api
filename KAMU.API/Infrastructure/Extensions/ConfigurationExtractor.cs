using KAMU.API.Infrastructure.Utilities;

namespace KAMU.API.Infrastructure.Extensions
{
    public static class ConfigurationExtractor
    {
        private static string ExtractConnectionString(IConfiguration configuration)
        {
            return configuration.GetConnectionString("KamuDB");
        }

        public static ApplicationSettings ExtractAppConfigurations(this IConfiguration configuration)
        {
            return new ApplicationSettings
            {
                ConnectionString = ExtractConnectionString(configuration)
            };
        }
    }
}
