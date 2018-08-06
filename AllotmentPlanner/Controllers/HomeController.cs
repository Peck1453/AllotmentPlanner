using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using AllotmentPlanner.Data;
using AllotmentPlanner.Services.Service;
using AllotmentPlanner.Models;



namespace AllotmentPlanner.Controllers { }
    public class HomeController : Controller
    {
        public GardenService _gardenService;

             public HomeController()
             {
                _gardenService = new GardenService();
             }
    
        public ActionResult Index()
        {
                return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AdminDashboard()
        {
            var userId = User.Identity.GetUserId();

            ViewBag.GardenCheck = _gardenService.CountUserActiveGardens(userId).Count();
            ViewBag.NoGarden = "You do not have a Garden Yet, please select one from the Dashboard";

            return View();

        }
    }
