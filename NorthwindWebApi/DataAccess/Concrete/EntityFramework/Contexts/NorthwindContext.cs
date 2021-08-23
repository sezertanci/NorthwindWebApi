using DataAccess.DataSeed;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString());

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity => { entity.HasIndex(i => i.Email).IsUnique(); });

            modelBuilder.Entity<UserOperationClaim>(entity =>
            {
                entity.HasIndex(i => new { i.UserId, i.OperationClaimId }).IsUnique();
                entity.HasOne<User>().WithMany().HasForeignKey(x => x.UserId).IsRequired();
                entity.HasOne<OperationClaim>().WithMany().HasForeignKey(x => x.OperationClaimId).IsRequired();
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(x => x.ProductId);
                entity.HasOne<Category>().WithMany().HasForeignKey(x => x.CategoryId).IsRequired();
                entity.HasOne<Supplier>().WithMany().HasForeignKey(x => x.SupplierId).IsRequired();
            });

            modelBuilder.Entity<Category>(entity => { entity.HasKey(x => x.CategoryId); });

            modelBuilder.Entity<Customer>(entity => { entity.HasKey(x => x.CustomerId); });

            modelBuilder.Entity<CustomerCustomerDemo>(entity =>
            {
                entity.HasKey(x => new { x.CustomerId, x.CustomerTypeId });
                entity.HasOne<Customer>().WithMany().HasForeignKey(x => x.CustomerId).IsRequired();
                entity.HasOne<CustomerDemographic>().WithMany().HasForeignKey(x => x.CustomerTypeId).IsRequired();
            });

            modelBuilder.Entity<CustomerDemographic>(entity => { entity.HasKey(x => x.CustomerTypeId); });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(x => x.EmployeeId);
                entity.HasOne<Employee>().WithMany().HasForeignKey(x => x.ReportsTo);
            });

            modelBuilder.Entity<EmployeeTerritory>(entity =>
            {
                entity.HasKey(x => new { x.EmployeeId, x.TerritoryId });
                entity.HasOne<Employee>().WithMany().HasForeignKey(x => x.EmployeeId).IsRequired();
                entity.HasOne<Territory>().WithMany().HasForeignKey(x => x.TerritoryId).IsRequired();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(x => x.OrderId);
                entity.HasOne<Employee>().WithMany().HasForeignKey(x => x.EmployeeId).IsRequired();
                entity.HasOne<Customer>().WithMany().HasForeignKey(x => x.CustomerId).IsRequired();
                entity.HasOne<Shipper>().WithMany().HasForeignKey(x => x.ShipVia).IsRequired();
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(x => new { x.OrderId, x.ProductId });
                entity.HasOne<Order>().WithMany().HasForeignKey(x => x.OrderId).IsRequired();
                entity.HasOne<Product>().WithMany().HasForeignKey(x => x.ProductId).IsRequired();
            });

            modelBuilder.Entity<Region>(entity => { entity.HasKey(x => x.RegionId); });

            modelBuilder.Entity<Shipper>(entity => { entity.HasKey(x => x.ShipperId); });

            modelBuilder.Entity<Supplier>(entity => { entity.HasKey(x => x.SupplierId); });

            modelBuilder.Entity<Territory>(entity =>
            {
                entity.HasKey(x => x.TerritoryId);
                entity.HasOne<Region>().WithMany().HasForeignKey(x => x.RegionId).IsRequired();
            });

            //modelBuilder.ApplyConfiguration(new UserSeed());
        }

        public DbSet<User> User { get; set; }
        public DbSet<OperationClaim> OperationClaim { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaim { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerCustomerDemo> CustomerCustomerDemo { get; set; }
        public DbSet<CustomerDemographic> CustomerDemographics { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTerritory> EmployeeTerritories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Territory> Territories { get; set; }

        private static string ConnectionString()
        {
            string path = Environment.CurrentDirectory + "\\appsettings.json";

            using (StreamReader r = File.OpenText(path))
            {
                string json = r.ReadToEnd();

                var parsed = JObject.Parse(json);

                var connectionString = parsed["connectionString"];

                return connectionString != null ? connectionString.ToString() : @"Server=(localdb)mssqllocaldb;Database=Northwind;integrated security=true";
            }
        }
    }
}
