namespace KAMU.API.Infrastructure.Services.Security
{
    /// <summary>
    /// Manages the user details gotten from the claims
    /// </summary>
    public interface IUserContext
    {
        /// <summary>
        /// User's id
        /// </summary>
        Guid CurrentUserId { get; set; }
        /// <summary>
        /// User's organisation id
        /// </summary>
        Guid OrganisationId { get; set; }

        /// <summary>
        /// User's email
        /// </summary>
        string Email { get; set; }
    }
}
