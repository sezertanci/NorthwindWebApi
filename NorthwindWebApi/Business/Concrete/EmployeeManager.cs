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
    public class EmployeeManager : IEmployeeService
    {
        private readonly IEmployeeDal _employeeDal;
        private readonly IMapper _mapper;

        public EmployeeManager(IEmployeeDal employeeDal, IMapper mapper)
        {
            _employeeDal = employeeDal;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(EmployeeValidator), Priority = 1)]
        [CacheRemoveAspect(pattern: "IEmployeeService.Get", Priority = 2)]
        public IDataResult<EmployeeView> Add(EmployeeView employeeView)
        {
            var data = _mapper.Map<Employee>(employeeView);

            _employeeDal.Add(data);

            return new SuccessDataResult<EmployeeView>(_mapper.Map<EmployeeView>(data), SuccessMessages.Success);
        }

        public IDataResult<EmployeeView> GetById(int id)
        {
            return new SuccessDataResult<EmployeeView>(_mapper.Map<EmployeeView>(_employeeDal.Get(x => x.EmployeeId == id)));
        }

        [ValidationAspect(typeof(EmployeeValidator), Priority = 1)]
        [CacheRemoveAspect(pattern: "IEmployeeService.Get", Priority = 2)]
        public IDataResult<EmployeeView> Update(EmployeeView employeeView)
        {
            var data = _mapper.Map<Employee>(employeeView);

            _employeeDal.Update(data);

            return new SuccessDataResult<EmployeeView>(_mapper.Map<EmployeeView>(data), SuccessMessages.Success);
        }

        public IDataResult<List<EmployeeView>> GetList()
        {
            return new SuccessDataResult<List<EmployeeView>>(_mapper.Map<List<EmployeeView>>(_employeeDal.GetList()));
        }

        public IResult Delete(int id)
        {
            _employeeDal.Delete(_employeeDal.Get(x => x.EmployeeId == id));

            return new SuccessResult(SuccessMessages.SuccessDeleted);
        }
    }
}

