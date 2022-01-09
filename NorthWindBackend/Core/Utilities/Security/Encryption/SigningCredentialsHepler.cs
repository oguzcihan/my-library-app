using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHepler
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            //şifrelenme algoritması
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        }


    }
}
