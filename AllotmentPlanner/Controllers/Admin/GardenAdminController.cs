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
        // GET: CropAdmin/Create
        [HttpGet]
        public ActionResult AddGarden()
        {
            return View();
        }

        // POST: CropAdmin/Create
        [HttpPost]
        public ActionResult AddGarden(GardenLocation garden, Allotment allotment)
        {

            try
            {
                _gardenService.addGarden(garden);
                _gardenService.addGardenAllotment(allotment);

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
            return View(_gardenService.GetGardenViewModel(pcode));
        }

        // POST: GardenAdmin/Edit/5
        [HttpPost]
        public ActionResult EditGarden(string pcode, GardenViewModel gardenViewModel, GardenLocation crop, Allotment allotment)
        {
            {
                try
                {
                    GardenLocation mygardenLocation = new GardenLocation
                    {
                        postCode = gardenViewModel.postCode,
                        Name = gardenViewModel.Name,
                        Owner = gardenViewModel.Owner
                    };


                    Allotment myAllotment = new Allotment
                    {
                        gardenID = gardenViewModel.gardenID,
                        size =     gardenViewModel.size,
                        postCode = gardenViewModel.postCode
                    };

                    _gardenService.editGarden(mygardenLocation, myAllotment);


                    return RedirectToAction("Gardens", new { controller = "Garden" });
                }
                catch
                {
                    return View();
                }
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
