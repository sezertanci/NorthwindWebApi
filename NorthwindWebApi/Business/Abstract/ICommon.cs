using Core.Utilities.Results;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICommon<T> where T : class, new()
    {
        public IDataResult<List<T>> GetList();
        public IDataResult<T> GetById(int id);
        public IDataResult<T> Add(T entity);
        public IDataResult<T> Update(T entity);
        public IResult Delete(int id);
    }
}
