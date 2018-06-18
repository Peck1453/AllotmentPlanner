using AllotmentPlanner.Services.Service;
using AllotmentPlanner.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllotmentPlanner.Controllers.Admin
{
    public class CropAdminController : ApplicationController
    {
        // GET: CropAdmin
        public ActionResult Index()
        {
            return View();
        }

        // GET: CropAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CropAdmin/Create
        [HttpGet]
        public ActionResult AddCrop()
        {
            return View();
        }

        // POST: CropAdmin/Create
        [HttpPost]
        public ActionResult AddCrop(Crop crop, CropHarvest croph, CropRequirements cropr)
        {
                
            try
            {
            _cropService.addCrop(crop);
            _cropService.addCropHarvest(croph);
            _cropService.addCropRequirements(cropr);
                
                return RedirectToAction("Crops", new { controller = "Crop" });
            }
            catch
            {
                return View();
            }
        }

        // GET: CropAdmin/Edit/5
        public ActionResult EditCrop(int id)
        {
            return View();
        }

        // POST: CropAdmin/Edit/5
        [HttpPost]
        public ActionResult EditCrop(int id, Crop crop, CropHarvest croph, CropRequirements cropr)
        {
            try
            {
                _cropService.editCrop(crop);
                _cropService.editCropHarvest(croph);
                _cropService.editCropRequirements(cropr);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CropAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CropAdmin/Delete/5
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
