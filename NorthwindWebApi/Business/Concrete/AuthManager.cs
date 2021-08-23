using Authentication.Hashing;
using Authentication.Jwt;
using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.Dto.ViewModel;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.ViewModel;
using System;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private IMapper _mapper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IMapper mapper = null)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _mapper = mapper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);

            return new SuccessDataResult<AccessToken>(accessToken, SuccessMessages.AccessTokenCreated);
        }

        public IDataResult<User> Login(LoginView loginView)
        {
            var userCheck = _userService.GetByEmail(loginView.Email);
            if(!userCheck.Success)
                return new ErrorDataResult<User>(ErrorMessages.UserNotFound);

            if(!HashingHelper.VerifyPasswordHash(loginView.Password, userCheck.Data.PasswordHash, userCheck.Data.PasswordSalt))
                return new ErrorDataResult<User>(ErrorMessages.PasswordError);

            return new SuccessDataResult<User>(userCheck.Data);
        }

        public IDataResult<User> Register(RegisterView registerView)
        {
            byte[] passwordHash, passwordSalt;

            HashingHelper.CreatePasswordHash(registerView.Password, out passwordHash, out passwordSalt);

            var user = new User
            {
                Email = registerView.Email,
                FirstName = registerView.FirstName,
                LastName = registerView.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            _userService.Add(user);

            return new SuccessDataResult<User>(user, SuccessMessages.UserRegistered);
        }

        public IResult UserExist(string email)
        {
            if(_userService.GetByEmail(email) != null)
                return new ErrorResult(ErrorMessages.UserAlreadyExists);

            return new SuccessResult();//605
        }
    }
}
