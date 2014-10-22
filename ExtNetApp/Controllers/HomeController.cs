using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime;
using CarDB.Model;
using Ext.Net;
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
            return View();}

        
        public void EditCarItem(int CarId, string Marks, string Model, string MakingCountry, string Continent)
        {
            carService.AddorEditCar(CarId, Marks, Model, MakingCountry, Continent);
        }
        public void DeleteCarItem(int CarId)
        {
            carService.DeleteCar(CarId);
        }
        public ActionResult GetAllCar()
        {
            var cars = carService.GetAllCars();
            var carViews = cars.Select(car => new CarViewModel()
            {
                CarId = car.CarId,
                Marks = car.Marks.Name,
                Model = car.Model,
                MakingCountry = car.MakingCountry.Name,
                Continent = car.MakingCountry.Continent
            }).ToList();

            return View(carViews);
        }        
    }
}
