using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDB.Model
{
    public class CarService
    {
        private readonly CarStoreEntities db = new CarStoreEntities();

        //public Car GetLanguage(string text)
        //{
        //    return db.Cars.FirstOrDefault(d => d.Word == text);
        //}

        public List<Car> GetAllCars()
        {
            if (db.Cars.Any())
            {  
                return db.Cars.ToList();
            }
            return null;
        }

        public Car GetCarById(int carId)
        {
            return db.Cars.FirstOrDefault(d => d.CarId == carId);
        }

        public void EditCar(int carId, string markName, string model, string country, string continent)
        {
            Car car = db.Cars.FirstOrDefault(d => d.CarId == carId);
            if (car != null)
            {
                car.Model = model;
                Mark mark = GetOrCreateMark(markName);
                car.Marks = mark;
                Country contry = GetOrCreateCountry(country);
                contry.Continent = continent;

            }
            db.SaveChanges();
        }

        public void AddCar(int carId, string markName, string model, string country, string continent)
        {
            Mark mark = GetOrCreateMark(markName);
            //car.Marks = mark;
            Country contry = GetOrCreateCountry(country);
            contry.Continent = continent;
            Car car = db.Cars.FirstOrDefault(d => d.Model == model);
            if (car == null)
            {
                car = new Car { Model = model, Marks = mark, MakingCountry = contry };
                db.Cars.Add(car);
                db.SaveChanges();
            }
        }

        public Mark GetOrCreateMark(string markName)
        {
            Mark mark = db.Marks.FirstOrDefault(m => m.Name == markName);
            if (mark == null)
            {
                mark = new Mark { Name = markName };
                db.Marks.Add(mark);
                db.SaveChanges();
            }
            return mark;
        }
        public Country GetOrCreateCountry(string countryName)
        {
            Country country = db.Countries.FirstOrDefault(c => c.Name == countryName);
            if (country == null)
            {
                country = new Country { Name = countryName };
                db.Countries.Add(country);
                db.SaveChanges();
            }
            return country;
        }
    }    
}
