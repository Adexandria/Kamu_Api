using KAMU.API.Infrastructure.Utilities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace KAMU.API.Infrastructure.Services.Security
{
    /// <summary>
    /// Manages token
    /// </summary>
    public class TokenManager : ITokenManager
    {
        /// <summary>
        /// A constructor
        /// </summary>
        /// <param name="tokenSecret">Manages token secret</param>
        /// <exception cref="ArgumentNullException"></exception>
        public TokenManager(ITokenSecret tokenSecret)
        {
            _tokenSecret = tokenSecret ?? throw new ArgumentNullException(nameof(tokenSecret), "Application secret key configuration can not be null");
        }
        /// <summary>
        /// Generates access token
        /// </summary>
        /// <param name="userDetails">User's details</param>
        /// <returns>access token</returns>
        public string GenerateAccessToken(UserDetails userDetails)
        {
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Claims = new Dictionary<string, object>()
                {
                    { JwtRegisteredClaimNames.NameId, userDetails.User.Id.ToString("N") },
                    { JwtRegisteredClaimNames.Email,userDetails.User.Email },
                    { "role",userDetails.Role.ToString() },
                    { "orgId",userDetails.User.Organisation?.Id.ToString("N") },
                    {JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()},
                    {JwtRegisteredClaimNames.Aud, _tokenSecret.Audience },
                    {JwtRegisteredClaimNames.Iss,_tokenSecret.Issuer }
                },
                Expires = DateTime.UtcNow.AddMinutes(_tokenSecret.ExpiryTimeInMins),
                SigningCredentials = new SigningCredentials(GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(securityTokenDescriptor);
            string token = tokenHandler.WriteToken(securityToken);

            return token;
        }

        /// <summary>
        /// Generates the security key
        /// </summary>
        /// <returns></returns>
        private SecurityKey GetSymmetricSecurityKey()
        {
            byte[] symmetricKey = Encoding.UTF8.GetBytes(_tokenSecret.SecretKey);
            return new SymmetricSecurityKey(symmetricKey);
        }

        private readonly ITokenSecret _tokenSecret;
    }
}
