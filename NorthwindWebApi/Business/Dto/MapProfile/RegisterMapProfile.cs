using AutoMapper;
using Business.Dto.ViewModel;
using Entities.ViewModel;

namespace Business.Dto.MapProfile
{
    public class RegisterMapProfile : Profile
    {
        public RegisterMapProfile()
        {
            CreateMap<RegisterView, UserForRegisterViewModel>();
        }
    }
}
