

using Microsoft.EntityFrameworkCore;
using ShopApp.DAL.Entities;


namespace ShopApp.DAL.Context
{
    public partial class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options) 
        { 
        }



        public DbSet<Category> Categories { get; set; }

        //public DbSet<Employee> Employees { get; set; }
        //public DbSet<Customer> Customers { get; set; }
        //public DbSet<Supplier> Suppliers { get; set; }

    

    }
}
