using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService : ICommon<User>
    {
        public IDataResult<List<OperationClaim>> GetClaims(User user);
        public IDataResult<User> GetByEmail(string email);
    }
}
