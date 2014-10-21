using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExtNetApp.Models
{
    public class CarViewModel
    {
        public int CarId { get; set; }
        public string Marks { get; set; }
        public string Model { get; set; }
        public string MakingCountry { get; set; }

        public string Continent { get; set; }
    }
}