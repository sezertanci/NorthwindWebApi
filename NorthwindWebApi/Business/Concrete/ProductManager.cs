using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.Dto.ViewModel;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly IMapper _mapper;

        public ProductManager(IProductDal productDal, IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(ProductValidator), Priority = 1)]
        [TransactionScopeAspect(Priority = 2)]
        public IDataResult<ProductView> Add(ProductView entity)
        {
            var data = _mapper.Map<Product>(entity);

            _productDal.Add(data);

            return new SuccessDataResult<ProductView>(_mapper.Map<ProductView>(data), SuccessMessages.Success);
        }

        public IResult Delete(int id)
        {
            _productDal.Delete(_productDal.Get(x => x.ProductId == id));

            return new SuccessResult(SuccessMessages.SuccessDeleted);
        }

        public IDataResult<List<ProductView>> DetailedList()
        {
            return new SuccessDataResult<List<ProductView>>(_mapper.Map<List<ProductView>>(_productDal.GetProducts()));
        }

        public IDataResult<object> DetailedOjectList()
        {
            return new SuccessDataResult<object>(_productDal.DetailedOjectList());
        }

        public IDataResult<ProductView> GetById(int id)
        {
            return new SuccessDataResult<ProductView>(_mapper.Map<ProductView>(_productDal.Get(x => x.ProductId == id)));
        }

        public IDataResult<List<ProductView>> GetList()
        {
            return new SuccessDataResult<List<ProductView>>(_mapper.Map<List<ProductView>>(_productDal.GetList()));
        }

        [ValidationAspect(typeof(ProductValidator), Priority = 1)]
        [TransactionScopeAspect(Priority = 2)]
        public IDataResult<ProductView> Update(ProductView entity)
        {
            var data = _mapper.Map<Product>(entity);

            _productDal.Update(data);

            return new SuccessDataResult<ProductView>(_mapper.Map<ProductView>(data), SuccessMessages.Success);
        }
    }
}
