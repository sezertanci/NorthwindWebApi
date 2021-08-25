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
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        private readonly IMapper _mapper;

        public CustomerManager(ICustomerDal customerDal, IMapper mapper)
        {
            _customerDal = customerDal;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(CustomerValidator), Priority = 1)]
        [CacheRemoveAspect(pattern: "ICustomerService.Get", Priority = 2)]
        public IDataResult<CustomerView> Add(CustomerView customerView)
        {
            var data = _mapper.Map<Customer>(customerView);

            _customerDal.Add(data);

            return new SuccessDataResult<CustomerView>(_mapper.Map<CustomerView>(data), SuccessMessages.Success);
        }

        public IDataResult<CustomerView> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<CustomerView> GetById(string id)
        {
            return new SuccessDataResult<CustomerView>(_mapper.Map<CustomerView>(_customerDal.Get(x => x.CustomerId == id)));
        }

        [ValidationAspect(typeof(CustomerValidator), Priority = 1)]
        [CacheRemoveAspect(pattern: "ICustomerService.Get", Priority = 2)]
        public IDataResult<CustomerView> Update(CustomerView customerView)
        {
            var data = _mapper.Map<Customer>(customerView);

            _customerDal.Update(data);

              return new SuccessDataResult<CustomerView>(_mapper.Map<CustomerView>(data), SuccessMessages.Success);
        }

        public IDataResult<List<CustomerView>> GetList()
        {
            return new SuccessDataResult<List<CustomerView>>(_mapper.Map<List<CustomerView>>(_customerDal.GetList()));
        }

        public IResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(string id)
        {
             _customerDal.Delete(_customerDal.Get(x => x.CustomerId == id));

            return new SuccessResult(SuccessMessages.SuccessDeleted);
        }
    }
}

