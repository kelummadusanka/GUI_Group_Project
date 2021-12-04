using GUI_Group_Project.Models;
using System.Data.Entity;

namespace GUI_Group_Project.Database
{
    class CustomerContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
    }
}
