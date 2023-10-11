namespace KAMU.API.Infrastructure.Utilities
{
    /// <summary>
    /// Manages the configuration to set up API
    /// </summary>
    public interface IDeploymentConfiguration
    {
        /// <summary>
        /// Super admin's first name
        /// </summary>
        string FirstName { get; set; }
        /// <summary>
        /// Super admin's last name
        /// </summary>
        string LastName { get; set; }
        /// <summary>
        /// Super admin's email
        /// </summary>
        string Email { get; set; }
        /// <summary>
        /// Super admin's password
        /// </summary>
        string Password { get; set; }
        /// <summary>
        /// Super admin's username
        /// </summary>
        string UserName { get; set; }
    }
}
