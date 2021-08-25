using Business.Dto.ViewModel;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface ICustomerService:ICommonService<CustomerView>
    {
        IDataResult<CustomerView> GetById(string id);
        IResult Delete(string id);
    }
}

