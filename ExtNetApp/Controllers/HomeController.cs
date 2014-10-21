using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarDB.Model;
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
            var carViews = new List<CarViewModel>();
            foreach (var car in cars)
            {
                carViews.Add(new CarViewModel()
                {
                    CarID = car.CarId,
                   // MakingCountry = car.MakingCountry.Name,
                    Marks = car.Marks.Name,
                    Model = car.Model
                });
            }

            return View(carViews);
        }

        public ActionResult Test()
        {
            return View(Companies.GetAllCompanies());
        }


    }
}
