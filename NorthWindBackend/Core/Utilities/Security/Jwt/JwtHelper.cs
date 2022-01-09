using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Core.Entities.Concrete;
using Core.Extension;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;


namespace Core.Utilities.Security.Jwt
{
    public class JwtHelper:ITokenHelper
    {
        //config dosyası ile token options bilgileri okunacak
        public IConfiguration Configuration { get;}
        private TokenOptions _tokenOptions;
        private DateTime _accesTokenExpiration;
        public JwtHelper(IConfiguration configuration) //iconfig in ne olduğunu anlatmam gerekir bunun için startup a yazıldı bknz.
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>(); //extension.binder
            _accesTokenExpiration=DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration); //token için zaman tarih verdik
        }
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            //token options okunacak jwt için altyapı
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey); //bir tane security key oluştur anlamına gelir.
            var signingCredentials = SigningCredentialsHepler.CreateSigningCredentials(securityKey); //hashlendi
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims); //token oluşturma
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt); //token parametre olarak verildi.

            return new AccessToken
            {
                Token = token,
                Expiration = _accesTokenExpiration

            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                    issuer:tokenOptions.Issuer,
                    audience:tokenOptions.Audience,
                    expires:_accesTokenExpiration,
                    notBefore:DateTime.Now,
                    claims: setClaims(user,operationClaims),
                    signingCredentials:signingCredentials
                    
                );

            return jwt;
        }

        private IEnumerable<Claim> setClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}"); //isim soyisim yazdırdım.
            claims.AddRoles(operationClaims.Select(c=>c.Name).ToArray()); //roller array yapıldı.

            return claims;
        }
    }
}
