using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDB.Model
{
    public class Car
    {
        public int CarId { get; set; }
        public virtual Mark Marks { get; set; }
        public string Model { get; set; }
        public virtual Country MakingCountry { get; set; }
    }
}
