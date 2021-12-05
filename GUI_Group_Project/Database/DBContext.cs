using GUI_Group_Project.Models;
using System.Data.Entity;

namespace GUI_Group_Project.Database
{
    class DBContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Boughtlotto> Boughtlottos { get; set; }
        public DbSet<Winninglotto> Winninglottos { get; set; }
    }
}
