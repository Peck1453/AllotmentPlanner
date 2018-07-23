﻿using AllotmentPlanner.Services.Service;
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
        [HttpGet]
        // GET: TendAdmin/Create
        public ActionResult AddTend()
        {
            return View();
        }

        // POST: TendAdmin/Create
        [HttpPost]
        public ActionResult AddTend(TendType tend)
        {
            try
            {
                _tendService.addTend(tend);

                return RedirectToAction("Tends", new { controller = "Tend" });
            }
            catch
            {
                return View();
            }
        }

        // GET: TendAdmin/Edit/5
        public ActionResult EditTend(int id)
        {
            return View(_tendService.getTend(id));
        }

        // POST: TendAdmin/Edit/5
        [HttpPost]
        public ActionResult EditTend(int id, TendType tend)
        {
            try
            {
                _tendService.editTend(tend);

                return RedirectToAction("Tends", new { controller = "Tend" });
            }
            catch
            {
                return View();
            }
        }

        // GET: TendAdmin/Delete/5
        public ActionResult DeleteTend(int id)
        {
            return View(_tendService.getTend(id));
        }

        // POST: TendAdmin/Delete/5
        [HttpPost]
        public ActionResult DeleteTend(int id, TendType tend)
        {
            try
            {
                TendType myTend = _tendService.getTend(id);
                _tendService.deleteTend(myTend);

                return RedirectToAction("Tends", new { controller = "Tend" });
            }
            catch
            {
                return View();
            }
        }


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

            return View(_gardenService.GetUserGarden(userId));

        }
    }
}
