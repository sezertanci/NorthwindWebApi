using AutoMapper;
using Business.Dto.ViewModel;
using Entities.ViewModel;

namespace Business.Dto.MapProfile
{
    public class LoginMapProfile:Profile
    {
        public LoginMapProfile()
        {
            CreateMap<LoginView, UserForLoginViewModel>();
        }
    }
}
