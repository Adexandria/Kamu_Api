namespace KAMU.API.Infrastructure.Utilities
{
    /// <summary>
    /// Manages application settings 
    /// </summary>
    public class ApplicationSettings
    {
        /// <summary>
        /// Connections string of database
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Manages token secret
        /// </summary>
        public ITokenSecret TokenSecret { get; set; }


        /// <summary>
        /// Manages the configuration to set up API
        /// </summary>
        public IDeploymentConfiguration DeploymentConfiguration {get;set;}
    }
}
