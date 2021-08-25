using AutoMapper;
using Business.Dto.ViewModel;
using Entities.Concrete;

namespace Business.Dto.MapProfile
{
    public class CustomerMapProfile : Profile
    {
        public CustomerMapProfile()
        {
            CreateMap<Customer, CustomerView>().ReverseMap();
        }
    }
}

