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
            carService.AddCar("volvo","kitten");
            return View();
        }


        public ActionResult GetAllCar()
        {
            var cars = carService.GetAllCars();
            var carViews = cars.Select(car => new CarViewModel()
            {
                CarId = car.CarId,
                // MakingCountry = car.MakingCountry.Name,
                Marks = car.Marks.Name, Model = car.Model
            }).ToList();

            return View(carViews);
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
