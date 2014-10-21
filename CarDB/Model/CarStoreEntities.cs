using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDB.Model
{
    public class CarStoreEntities : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}
