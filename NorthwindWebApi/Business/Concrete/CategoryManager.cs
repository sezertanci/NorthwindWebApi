using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.Dto.ViewModel;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Cache;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IMapper _mapper;

        public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(CategoryValidator), Priority = 1)]
        [CacheRemoveAspect(pattern: "ICategoryService.Get", Priority = 2)]
        public IDataResult<CategoryView> Add(CategoryView categoryView)
        {
            var data = _mapper.Map<Category>(categoryView);

            _categoryDal.Add(data);

            return new SuccessDataResult<CategoryView>(_mapper.Map<CategoryView>(data), SuccessMessages.Success);
        }

        public IDataResult<CategoryView> GetById(int id)
        {
            return new SuccessDataResult<CategoryView>(_mapper.Map<CategoryView>(_categoryDal.Get(filter: x => x.CategoryId == id)));
        }

        [ValidationAspect(typeof(CategoryValidator), Priority = 1)]
        [CacheRemoveAspect(pattern: "ICategoryService.Get", Priority = 2)]
        public IDataResult<CategoryView> Update(CategoryView categoryView)
        {
            var data = _mapper.Map<Category>(categoryView);

            _categoryDal.Update(data);

            return new SuccessDataResult<CategoryView>(_mapper.Map<CategoryView>(data), SuccessMessages.Success);
        }

        public IDataResult<List<CategoryView>> GetList()
        {
            return new SuccessDataResult<List<CategoryView>>(_mapper.Map<List<CategoryView>>(_categoryDal.GetList()));
        }

        public IResult Delete(int id)
        {
            _categoryDal.Delete(_categoryDal.Get(x => x.CategoryId == id));

            return new SuccessResult(SuccessMessages.SuccessDeleted);
        }
    }
}

