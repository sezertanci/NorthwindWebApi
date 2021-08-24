using AutoMapper;
using Business.Dto.ViewModel;
using Entities.Concrete;

namespace Business.Dto.MapProfile
{
    public class CategoryMapProfile : Profile
    {
        public CategoryMapProfile()
        {
            CreateMap<Category, CategoryView>();
            CreateMap<CategoryView, Category>();
        }
    }
}

