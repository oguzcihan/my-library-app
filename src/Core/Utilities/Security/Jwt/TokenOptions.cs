

namespace Core.Utilities.Security.Jwt
{
    public class TokenOptions
    {
        /// <summary>
        /// Kullanıcı kitlesi
        /// </summary>
        public string Audience { get; set; }
        /// <summary>
        /// İmzalayıcısı
        /// </summary>
        public string Issuer { get; set; }
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}
