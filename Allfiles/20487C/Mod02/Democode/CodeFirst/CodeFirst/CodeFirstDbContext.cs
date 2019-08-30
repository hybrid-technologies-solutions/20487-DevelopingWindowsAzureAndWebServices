using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class CodeFirstDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }
    }
}
