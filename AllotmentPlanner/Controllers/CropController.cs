﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllotmentPlanner.Controllers
{
    public class CropController : ApplicationController

    {

        //    public CropController()
        //{

        //}
        
        
        // GET: Crop
        public ActionResult Crops()

        {
            return View(_cropService.GetCrops());
        }

        // GET: Crop/Details/5
        
        public ActionResult CropDetails(int id)
        {
            
            return View(_cropService.GetCropViewModel(id));
        }

        // GET: Crop/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Crop/Create
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

        // GET: Crop/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Crop/Edit/5
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

        // GET: Crop/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Crop/Delete/5
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