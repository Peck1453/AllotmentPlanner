using AllotmentPlanner.Services.Service;
using AllotmentPlanner.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AllotmentPlanner.Data.ViewModel;
using Microsoft.AspNet.Identity;


namespace AllotmentPlanner.Controllers.Admin
{
    public class TendAdminController : ApplicationController
    {
        // GET: TendAdmin/Create
        [HttpGet]
        [Authorize(Roles = "Administrator")]

        public ActionResult AddTend()
        {
            return View();
        }

        // POST: TendAdmin/Create
        [HttpPost]
        [Authorize(Roles = "Administrator")]

        public ActionResult AddTend(TendType tend)
        {
            try
            {
                _tendService.addTend(tend);

                var planted = _gardenService.getPlantedCrops();
                TendType lastcreated = _tendService.GetLastTendCreated();


                foreach (var plant in planted)
                {
                    Tended myTended = new Tended
                    {
                        cropId = plant.cropId,
                        plantedId = plant.plantedId,
                        tendId = lastcreated.tendId,
                        Date = DateTime.Now
                    };
                    _tendService.setAsTended(myTended);

                }


                return RedirectToAction("Tends", new { controller = "Tend" });
            }
            catch (Exception ex)
            {
                //  Might be worth looking at redirection to an error page
                ViewBag.Exception = ex;
                return View();
            }
        }

        // GET: TendAdmin/Edit/5
        [Authorize(Roles = "Administrator")]
        public ActionResult EditTend(int id)
        {
            return View(_tendService.getTend(id));
        }

        // POST: TendAdmin/Edit/5
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult EditTend(int id, TendType tend)
        {
            try
            {
                _tendService.editTend(tend);

                return RedirectToAction("Tends", new { controller = "Tend" });
            }
            catch (Exception ex)
            {
                //  Might be worth looking at redirection to an error page
                ViewBag.Exception = ex;
                return View();
            }
        }

        // GET: TendAdmin/Delete/5
        [HttpGet]
        [Authorize(Roles = "Administrator")]

        public ActionResult DeleteTend(int id)
        {
            return View(_tendService.getTend(id));
        }

        // POST: TendAdmin/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult DeleteTend(int id, TendType tend)
        {
            try
            {
                TendType myTend = _tendService.getTend(id);
                _tendService.deleteTend(myTend);

                return RedirectToAction("Tends", new { controller = "Tend" });
            }
            catch (Exception ex)
            {
                //  Might be worth looking at redirection to an error page
                ViewBag.Exception = ex;
                return View();
            }
        }

        [HttpGet]
        public ActionResult setAsTended(Tended tended, CropMaintenanceViewModel cropMaintenance)
        {
            var userId = User.Identity.GetUserId();
            Tended myTended = new Tended
            {
                cropId = cropMaintenance.cropId,
                tendId = cropMaintenance.tendId,
                Date = DateTime.Now,
                plantedId = cropMaintenance.plantedId
            };

            _tendService.setAsTended(myTended);

            return RedirectToAction("GetUserGarden", new { controller = "Garden" });
        }
    }
}
