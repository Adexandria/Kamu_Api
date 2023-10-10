namespace KAMU.API.Infrastructure.Utilities
{
    /// <summary>
    /// Manages Token Secret
    /// </summary>
    public class TokenSecret : ITokenSecret
    {
        /// <summary>
        /// Token issuer
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// Token audience
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// Secret key
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// Expiration time in mins
        /// </summary>
        public int ExpiryTimeInMins { get; set; }
    }
}
