using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public object DetailedOjectList()
        {
            using NorthwindContext context = new NorthwindContext();

            var query = from Product in context.Products
                        join Category in context.Categories on Product.CategoryId equals Category.CategoryId into CategoryList
                        from Category in CategoryList.DefaultIfEmpty()
                        join Supplier in context.Suppliers on Product.SupplierId equals Supplier.SupplierId into SupplierList
                        from Supplier in SupplierList.DefaultIfEmpty()
                        select new
                        {
                            Product.Discontinued,
                            Product.ProductId,
                            Product.ProductName,
                            Product.QuantityPerUnit,
                            Product.ReorderLevel,
                            Product.UnitPrice,
                            Product.UnitsInStock,
                            Product.UnitsOnOrder,
                            CategoryId = Category != null ? Category.CategoryId : 0,
                            CategoryName = Category != null ? Category.CategoryName : null,
                            CategoryDescription = Category != null ? Category.Description : null,
                            SupplierId = Supplier != null ? Supplier.SupplierId : 0,
                            SupplierAddress = Supplier != null ? Supplier.Address : null,
                            SupplierCity = Supplier != null ? Supplier.City : null,
                            SupplierCompanyName = Supplier != null ? Supplier.CompanyName : null,
                            SupplierContactName = Supplier != null ? Supplier.ContactName : null,
                            SupplierContactTitle = Supplier != null ? Supplier.ContactTitle : null,
                            SupplierCountry = Supplier != null ? Supplier.Country : null,
                            SupplierFax = Supplier != null ? Supplier.Fax : null,
                            SupplierHomePage = Supplier != null ? Supplier.HomePage : null,
                            SupplierHomePhone = Supplier != null ? Supplier.Phone : null,
                            SupplierPostalCode = Supplier != null ? Supplier.PostalCode : null,
                            SupplierRegion = Supplier != null ? Supplier.Region : null
                        };

            return query.ToList();
        }

        public List<Product> GetProducts()
        {
            using NorthwindContext context = new NorthwindContext();

            return context.Products.Include(x => x.Category).ToList();
        }
    }
}
