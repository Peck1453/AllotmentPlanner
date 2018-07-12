using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using AllotmentPlanner.Data;

using System.Web.Mvc;
using AllotmentPlanner.Data.ViewModel;

namespace AllotmentPlanner.Controllers
{
    public class GardenController : ApplicationController
    {
        // GET: Garden
        public ActionResult Gardens()
        {
            return View(_gardenService.GetGardenLocations());
        }

        public ActionResult ViewSelectedCrops()
        {
            var userID = User.Identity.GetUserId();

            return View(_gardenService.ViewSelectedCrops(userID));
        }

        public ActionResult ListSelectedCrops()
        {
            var userId = User.Identity.GetUserId();
            return View(_gardenService.ListSelectedCrops(userId));
        }

        public ActionResult ViewGardensinLocation(string pcode)
        {

            return View(_gardenService.ViewGardensinLocation(pcode));

        }

        public ActionResult _ViewEmptyGardensinLocation(string pcode)
        {

            return View(_gardenService.ViewEmptyGardensinLocation(pcode));

        }




        // GET: Garden/Details/5
        public ActionResult GardenDetails(string pcode)
        {
            return View(_gardenService.GetGardenViewModel(pcode));
        }
        [HttpGet]
        // GET: Garden/Create
        public ActionResult _addcropstogarden(string selectedCrop)
        {
            //var userId = User.Identity.GetUserId();
                List<SelectListItem> cropList = new List<SelectListItem>();
                foreach (var crop in _cropService.GetCrops())
                {
                    cropList.Add(
                      new SelectListItem()
                      {
                          Text = crop.cropName,
                          Value = crop.cropId.ToString(),
                          Selected = (crop.cropName == (selectedCrop) ? true : false)
                      });
                }
                ViewBag.cropList = cropList;

            return View();
        }

        // POST: Garden/Create
        [HttpPost]
        public ActionResult _addcropstogarden(Planted crop, Planted garden, GardenViewModel gardenViewModel)
        {
            var userId = User.Identity.GetUserId();
            var usergarden = _gardenService.GetGardenFromUser(userId);
            try
            {
                Planted myusergarden = new Planted
                {
                    gardenId = usergarden.gardenId
                };

            

                _gardenService.addcropstogarden(userId, crop, myusergarden);

            return View();
        
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
