using AutoMapper;
using Business.Dto.ViewModel;
using Entities.Concrete;

namespace Business.Dto.MapProfile
{
    public class EmployeeMapProfile : Profile
    {
        public EmployeeMapProfile()
        {
            CreateMap<Employee, EmployeeView>().ReverseMap();
        }
    }
}

