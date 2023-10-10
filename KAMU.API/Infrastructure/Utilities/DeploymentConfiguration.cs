namespace KAMU.API.Infrastructure.Utilities
{
    /// <summary>
    /// Manages the configuration to set up API
    /// </summary>
    public class DeploymentConfiguration : IDeploymentConfiguration
    {
        /// <summary>
        /// Super admin's first name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Super admin's last name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Super admin's email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Super admin's password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Super admin's username
        /// </summary>
        public string UserName { get; set; }
    }
}