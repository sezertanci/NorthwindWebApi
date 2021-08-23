using Authentication.Jwt;
using Business.Dto.ViewModel;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.ViewModel;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(RegisterView registerView);
        IDataResult<User> Login(LoginView loginView);
        IResult UserExist(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
