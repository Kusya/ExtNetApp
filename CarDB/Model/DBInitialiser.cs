using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDB.Model
{

    public class DBInitialiser : DropCreateDatabaseAlways<CarStoreEntities>
        {
            protected override void Seed(CarStoreEntities context)
            {
                GetCategories().ForEach(c => context.Cars.Add(c));
            }

            private static List<Car> GetCategories()
            {
                var categories = new List<Car> {
                new Car
                {
                    CarId = 1,
                    Marks = new Mark {MarkID = 1, Name = "Audi"},
                    Model = "A8",
                    MakingCountry = new Country{CountryID=1, Name = "Germany", Continent="Europe"}

                },
                new Car
                {
                    CarId = 1,
                    Marks = new Mark{MarkID = 2, Name = "Lada"},
                    Model = "Calina",
                    MakingCountry = new Country{CountryID=2, Name = "Russia", Continent="Asia"}
                },
                new Car
                {
                   CarId = 1,
                    Marks = new Mark{MarkID = 3, Name =  "Toyota"},
                    Model = "Camry",
                    MakingCountry = new Country{CountryID=3, Name = "Japan", Continent="Asia"}
                }
            };
                return categories;
            }
        }
    
}
