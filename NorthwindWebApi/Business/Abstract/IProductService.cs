using Business.Dto.ViewModel;
using Core.Utilities.Results;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IProductService : ICommonService<ProductView>
    {
        IDataResult<object> DetailedOjectList();
        IDataResult<List<ProductView>> DetailedList();
    }
}
