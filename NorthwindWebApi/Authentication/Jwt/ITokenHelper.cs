using Entities.Concrete;
using System.Collections.Generic;

namespace Authentication.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
