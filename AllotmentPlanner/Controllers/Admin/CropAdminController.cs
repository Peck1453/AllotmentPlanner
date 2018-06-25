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
            //try
            //{
            Crop myCrop = new Crop
            {
                cropID = cropDataViewModel.CropId,
                cropName = cropDataViewModel.CropName,
                cropSize = cropDataViewModel.SpaceRequired
            };


            CropHarvest myCroph = new CropHarvest
            {
                cropID = cropHarvest.cropID,
                earliestHarvest = cropHarvest.earliestHarvest,
                latestHarvest = cropHarvest.latestHarvest,
                earliestPlant = cropHarvest.earliestPlant,
                latestPlant = cropHarvest.latestPlant,
                growthTime = cropHarvest.growthTime,
                };


            CropRequirements myCropr = new CropRequirements
            {
                cropID = cropRequirements.cropID,
                birdNetting = cropRequirements.birdNetting,
                slugPellets = cropRequirements.slugPellets,
                Feed = cropRequirements.Feed,
                Water = cropRequirements.Water,
            };

                _cropService.editCrop(myCrop, myCroph, myCropr);


                return  RedirectToAction("Crops", new { controller = "Crop" });
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: CropAdmin/Delete/5
        public ActionResult DeleteCrop(int id) //Pulls the method for displaying the requested Product
        {
            return View(_cropService.GetCropViewModel(id));
        }

        [HttpPost]
        public ActionResult DeleteCrop(int id, CropDataViewModel cropDataViewModel) //Deletes the requested Product (identified by the Product ID)
        {
            try
            {
                {
                    Crop myCrop = _cropService.GetCrop(id);
                    _cropService.DeleteCrop(myCrop);
                }

                {
                    CropHarvest myCropHarvest = _cropService.GetCropHarvest(id);
                    _cropService.DeleteCropHarvest(myCropHarvest);

                }

                {
                    CropRequirements myCropRequirements = _cropService.GetCropRequirements(id);
                    _cropService.DeleteCropRequirements(myCropRequirements);

                }

            }
            catch
            {

            }
            return RedirectToAction("Crops", new { controller = "Crop" });
        }
    }
}
