using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllotmentPlanner.Controllers
{
    public class GardenController : ApplicationController
    {
        // GET: Garden
        public ActionResult Gardens()
        {
            return View(_gardenService.GetGardenLocations());
        }

        // GET: Garden/Details/5
        public ActionResult GardenDetails(string pcode)
        {
            return View(_gardenService.GetGardenViewModel(pcode));
        }

        // GET: Garden/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Garden/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Garden/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Garden/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
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

        // GET: Garden/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Garden/Delete/5
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
