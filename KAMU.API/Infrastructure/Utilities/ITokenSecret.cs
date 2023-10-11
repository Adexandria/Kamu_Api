namespace KAMU.API.Infrastructure.Utilities
{
    /// <summary>
    /// Manages Token Secret
    /// </summary>
    public interface ITokenSecret
    {
        /// <summary>
        /// Token issuer
        /// </summary>
        string Issuer { get; set; }
        /// <summary>
        /// Token audience
        /// </summary>
        string Audience { get; set; }
        /// <summary>
        /// Secret key
        /// </summary>
        string SecretKey { get; set; }
        /// <summary>
        /// Expiration time in mins
        /// </summary>
        int ExpiryTimeInMins { get; set; }
    }
}
