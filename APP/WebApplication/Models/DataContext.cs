using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MySql.Data.Entity;

namespace WebApplication.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DataContext:DbContext
    {
        
        public DataContext(): base("DefaultConnection") 
        {
            this.Configuration.ValidateOnSaveEnabled = false;
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}