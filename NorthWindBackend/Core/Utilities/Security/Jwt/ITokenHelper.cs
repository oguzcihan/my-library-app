using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;

namespace Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        //json web token ile yaparım başka bir teknik geldiğinde onunla yapabilirim.
        AccessToken CreateToken(User user,List<OperationClaim> operationClaims);
    }
}
