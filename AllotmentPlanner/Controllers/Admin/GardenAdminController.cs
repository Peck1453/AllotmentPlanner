using AllotmentPlanner.Services.Service;
using AllotmentPlanner.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AllotmentPlanner.Data.ViewModel;


namespace AllotmentPlanner.Controllers.Admin
{
    public class GardenAdminController : ApplicationController
    {
        // GET: GardenAdmin
        public ActionResult Index()
        {
            return View();
        }

        // GET: GardenAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [HttpGet]
        // GET: GardenAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GardenAdmin/Create
        [HttpPost]
        public ActionResult AddGarden(GardenLocation gardenLocation)
        {
            try
            {
                _gardenService.addGarden(gardenLocation);

                return RedirectToAction("Gardens", new { controller = "Garden" });
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        // GET: GardenAdmin/Edit/5
        public ActionResult EditGarden(string pcode)
        {
            return View(_gardenService.GetGardenLocation(pcode));
        }

        // POST: GardenAdmin/Edit/5
        [HttpPost]
        public ActionResult EditGarden(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GardenAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GardenAdmin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
