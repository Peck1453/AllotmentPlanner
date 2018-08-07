﻿using AllotmentPlanner.Services.Service;
using AllotmentPlanner.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AllotmentPlanner.Data.ViewModel;

namespace AllotmentPlanner.Controllers.Admin
{
    public class CropAdminController : ApplicationController
    {


        // GET: CropAdmin/Create
        [HttpGet]
        public ActionResult AddCrop()
        {
            return View();
        }

        // POST: CropAdmin/Create
        [HttpPost]
        public ActionResult AddCrop(Crop crop, CropHarvest croph, CropRequirements cropr, CropDataViewModel cropDataViewModel)
        {                
            try
            {
                Crop mycrop = new Crop
                {
                    cropId = cropDataViewModel.CropId,
                    cropName = cropDataViewModel.CropName,
                    cropSize = cropDataViewModel.SpaceRequired
                };

                _cropService.addCrop(mycrop);

                CropHarvest myCroph = new CropHarvest
                {
                    cropId = cropDataViewModel.CropId,
                    earliestHarvest = cropDataViewModel.EarlyHarvest,
                    latestHarvest = cropDataViewModel.LateHarvest,
                    earliestPlant = cropDataViewModel.EarlyPlanting,
                    latestPlant = cropDataViewModel.LatePlanting,
                    growthTime = cropDataViewModel.growthTime,
                };

                _cropService.addCropHarvest(myCroph);

                _cropService.addCropRequirements(cropr);
                
                return RedirectToAction("Crops", new { controller = "Crop" });
            }
            catch (Exception ex)
            {
                // DS - Might be worth looking at redirection to an error page or something?
                ViewBag.Exception = ex;
                return View();
            }
        }

        [HttpGet]
        // GET: CropAdmin/Edit/5
        public ActionResult EditCrop(int id)
        {
            return View(_cropService.GetCropViewModel(id));
        }

        // POST: CropAdmin/Edit/5
        [HttpPost]
        public ActionResult EditCrop(int id, CropDataViewModel cropDataViewModel, Crop crop, CropHarvest cropHarvest, CropRequirements cropRequirements)
        {
            try
            {
                Crop myCrop = new Crop
                {
                    cropId = cropDataViewModel.CropId,
                    cropName = cropDataViewModel.CropName,
                    cropSize = cropDataViewModel.SpaceRequired
                };

                CropHarvest myCroph = new CropHarvest
                {
                    cropId = cropDataViewModel.CropId,
                    earliestHarvest = cropDataViewModel.EarlyHarvest,
                    latestHarvest = cropDataViewModel.LateHarvest,
                    earliestPlant = cropDataViewModel.EarlyPlanting,
                    latestPlant = cropDataViewModel.LatePlanting,
                    growthTime = cropDataViewModel.growthTime
                };

                CropRequirements myCropr = new CropRequirements
                {
                    cropId = cropRequirements.cropId,
                    birdNetting = cropRequirements.birdNetting,
                    slugPellets = cropRequirements.slugPellets,
                    Feed = cropRequirements.Feed,
                    wateringInterval = cropRequirements.wateringInterval
                };

                // DS - I'd seperate this off into different methods to help identify, if anything went wrong, where the problem is
                _cropService.editCrop(myCrop, myCroph, myCropr);
                
                return RedirectToAction("Crops", new { controller = "Crop" });
            }
            catch
            {
                return View();
            }
        }

        // GET: CropAdmin/Delete/5
        [HttpGet]
        public ActionResult DeleteCrop(int id) //Pulls the method for displaying the requested Product
        {
            return View(_cropService.GetCropViewModel(id));
        }

        [HttpPost]
        public ActionResult DeleteCrop(int id, CropDataViewModel cropDataViewModel) //Deletes the requested Product (identified by the Product ID)
        {
            try
            {
                Crop myCrop = _cropService.GetCrop(id);
                _cropService.DeleteCrop(myCrop);

                CropHarvest myCropHarvest = _cropService.GetCropHarvest(id);
                _cropService.DeleteCropHarvest(myCropHarvest);

                CropRequirements myCropRequirements = _cropService.GetCropRequirements(id);
                _cropService.DeleteCropRequirements(myCropRequirements);

            }
            catch (Exception ex)
            {
                // DS - Might be worth looking at redirection to an error page or something?
                ViewBag.Exception = ex;
                return View();
            }

            return RedirectToAction("Crops", new { controller = "Crop" });
        }
    }
}
