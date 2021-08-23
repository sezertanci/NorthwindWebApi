using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<User> Add(User entity)
        {
            _userDal.Add(entity);

            return new SuccessDataResult<User>(entity, SuccessMessages.Success);
        }

        public IResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> GetByEmail(string email)
        {
            var data = _userDal.Get(u => u.Email == email);
            if(data == null) return new ErrorDataResult<User>(data);
            return new SuccessDataResult<User>(data);
        }

        public IDataResult<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IDataResult<List<User>> GetList()
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
