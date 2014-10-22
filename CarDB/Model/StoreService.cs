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

        public void AddorEditCar(int carId, string markName, string model, string country, string continent)
        {
            Car car = db.Cars.FirstOrDefault(d => d.CarId == carId);
            if (car == null)
            {
                AddCar(markName, model, country, continent);
            }
            else
            {
                EditCar(car, markName, model, country, continent);
            }
        }

        public void EditCar(Car car, string markName, string model, string country, string continent)
        {
            Mark mark = GetOrCreateMark(markName);
            Country contry = GetOrCreateCountry(country);
            contry.Continent = continent;
            car.Marks = mark;
            car.Model = model;
            car.MakingCountry = contry;
            db.SaveChanges();
        }

        public void AddCar(string markName, string model, string country, string continent)
        {
            Mark mark = GetOrCreateMark(markName);
            Country contry = GetOrCreateCountry(country);
            contry.Continent = continent;
            var car = new Car { Model = model, Marks = mark, MakingCountry = contry };
            db.Cars.Add(car);
            db.SaveChanges();
        }

        public void DeleteCar(int carId)
        {
            Car car = db.Cars.FirstOrDefault(d => d.CarId == carId);
            if (car != null)
            {
                db.Cars.Remove(car);
                db.SaveChanges();
            }
        }

        //private section
        private Mark GetOrCreateMark(string markName)
        {
            Mark mark = db.Marks.FirstOrDefault(m => m.Name == markName);
            if (mark == null)
            {
                mark = new Mark { Name = markName };
                db.Marks.Add(mark);
                db.SaveChanges();
            }
            else if (mark.Name == "")
            {
                mark.Name = markName;
                db.SaveChanges();
            }
            return mark;
        }
        private Country GetOrCreateCountry(string countryName)
        {
            Country country = db.Countries.FirstOrDefault(c => c.Name == countryName);
            if (country == null)
            {
                country = new Country { Name = countryName };
                db.Countries.Add(country);
                db.SaveChanges();
            }
            else if (country.Name == "")
            {
                country.Name = countryName;
                db.SaveChanges();
            }
            return country;
        }
    }
}
