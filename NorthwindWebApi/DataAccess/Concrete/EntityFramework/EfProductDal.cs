using DataAccess.Abstract;
using Core.DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
    }
}
