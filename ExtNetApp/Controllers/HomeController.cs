using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime;
using CarDB.Model;
using Ext.Net;
using Ext.Net.MVC.Examples.Areas.GridPanel_Commands.Row_Command;
using ExtNetApp.Models;

namespace ExtNetApp.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private readonly CarService carService = new CarService();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateCar()
        {       
            carService.AddCar(4,"volvo","kitten","finland","eorope");
            return View();
        }

        public void EditCarItem(int CarId, string Marks, string Model, string MakingCountry, string Continent)
        {
            carService.AddCar(CarId, Marks, Model, MakingCountry, Continent);

        }

        public ActionResult GetAllCar()
        {
            //var cars = carService.GetAllCars();
            //var carViews = cars.Select(car => new CarViewModel()
            //{
            //    CarId = car.CarId,
            //    // MakingCountry = car.MakingCountry.Name,
            //    Marks = car.Marks.Name, Model = car.Model
            //}).ToList();

            //return View(carViews);
           
            return View(GetData());
		
        }
        private object[] GetData()
        {
            return new object[]
            {
                new object[] { "3m Co", 71.72, 0.02, 0.03, "9/1 12:00am" },
                new object[] { "Alcoa Inc", 29.01, 0.42, 1.47, "9/1 12:00am" },
                new object[] { "Altria Group Inc", 83.81, 0.28, 0.34, "9/1 12:00am" },
                new object[] { "American Express Company", 52.55, 0.01, 0.02, "9/1 12:00am" }
            };
        }
        public ActionResult Test()
        
        {
            var cars = carService.GetAllCars();
            var carViews = cars.Select(car => new CarViewModel()
            {
                CarId = car.CarId,
                MakingCountry = "no",
                Marks = car.Marks.Name,
                Model = car.Model,
                Continent = "no"
            }).ToList();

            //var carViews = cars.Select(car => new
            //{
            //    car.CarId,
            //    Mark = car.Marks == null ? "No mark" : car.Marks.Name,
            //    Model = car.Model ?? "No model",
            //    car.MakingCountry,
            //    Continent = "No continent"
            //});

            return View(carViews);
            //return View(Companies.GetAllCompanies());
        }


    }
}
