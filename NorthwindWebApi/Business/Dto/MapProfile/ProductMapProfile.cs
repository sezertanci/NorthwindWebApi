using AutoMapper;
using Business.Dto.ViewModel;
using Entities.Concrete;

namespace Business.Dto.MapProfile
{
    public class ProductMapProfile : Profile
    {
        public ProductMapProfile()
        {
            CreateMap<Product, ProductView>().ReverseMap();
        }
    }
}
