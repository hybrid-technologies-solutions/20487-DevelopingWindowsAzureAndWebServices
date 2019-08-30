using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbInitializer = new CreateDatabaseIfNotExists<CodeFirstDbContext>();
            dbInitializer.InitializeDatabase(new CodeFirstDbContext());
            Console.Read();
        }
    }
}
