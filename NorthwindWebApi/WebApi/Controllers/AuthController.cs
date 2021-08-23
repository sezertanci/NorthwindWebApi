using Business.Abstract;
using Business.Dto.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost(template: "[action]")]
        public IActionResult Register([FromBody] RegisterView registerView)
        {
            var userExist = _authService.UserExist(registerView.Email);

            if(!userExist.Success) return BadRequest(userExist.Message);

            var registerResult = _authService.Register(registerView);

            var result = _authService.CreateAccessToken(registerResult.Data);

            if(result.Success) return Ok(result);

            return BadRequest(result);
        }

        [HttpPost(template: "[action]")]
        public IActionResult Login([FromBody] LoginView loginView)
        {
            var loginUser = _authService.Login(loginView);

            if(!loginUser.Success) return BadRequest(loginUser.Message);

            var result = _authService.CreateAccessToken(loginUser.Data);

            if(result.Success)
            {
                var data = new LoginUserView
                {
                    Id = loginUser.Data.Id,
                    FirstName = loginUser.Data.FirstName,
                    LastName = loginUser.Data.LastName,
                    Token = result.Data.Token
                };

                return Ok(data);
            }

            return BadRequest(result.Message);
        }
    }
}
