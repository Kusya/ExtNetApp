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

        public Car GetCarById(int CarID)
        {
            return db.Cars.FirstOrDefault(d => d.CarID == CarID);
        }

        public void EditCar(int CarID, string markName, string model)
        {
            Car car = db.Cars.FirstOrDefault(d => d.CarID == CarID);
            car.Model = model;
            Mark mark = GetOrCreateMark(markName);
            car.Marks = mark;
            db.SaveChanges();
        }

        public void AddCar(string markName, string model)
        {
            Mark mark = GetOrCreateMark(markName);
            Car car = db.Cars.FirstOrDefault(d => d.Model == model);
            if (car == null)
            {
                car = new Car { Model = model, Marks = mark };
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
    }    
}
