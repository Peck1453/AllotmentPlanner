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
        [HttpGet]
        public ActionResult Gardens()
        {
            return View(_gardenService.GetGardenLocations());
        }

        [HttpGet]
        public ActionResult ListSelectedCrops()
        {
            var userId = User.Identity.GetUserId();
            return View(_gardenService.ListSelectedCrops(userId));
        }

        [HttpGet]
        public ActionResult GetUserGarden()
        {
            var userId = User.Identity.GetUserId();
            return View(_gardenService.GetUserGarden(userId));
        }

        [HttpGet]
        public ActionResult ViewGardensinLocation(string pcode)
        {
            ViewBag.PostCode = pcode;

            return View(_gardenService.ViewGardensinLocation(pcode));
        }

        [HttpGet]
        public ActionResult _ViewEmptyGardensinLocation(string pcode)
        {
            return PartialView(_gardenService.ViewEmptyGardensinLocation(pcode));
        }

        [HttpGet]
        public ActionResult UserViewEmptyGardensinLocation(string pcode)
        {
            return View(_gardenService.ViewEmptyGardensinLocation(pcode));
        }

        [HttpGet]
        public ActionResult UserAssignSelftoGarden(int gardenId, AllotmentAllocation allotmentAllocation)
        {
            var userId = User.Identity.GetUserId();
            try
            {
                AllotmentAllocation myallotmentAllocation = new AllotmentAllocation
                {
                    userId = userId,
                    gardenId = gardenId,
                    dateFrom = DateTime.Now
                };

                _gardenService.assignGardenerToGarden(myallotmentAllocation);
                return RedirectToAction("GetUserGarden", new { controller = "Garden" });
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult _userSelectPostcode(string pcode)
        {
            List<SelectListItem> postCodeList = new List<SelectListItem>();
            foreach (var location in _gardenService.GetGardenLocations())
            {
                postCodeList.Add(
                    new SelectListItem()
                    {
                        Text = location.postCode,
                        Value = location.postCode.ToString(),
                        Selected = (location.postCode == pcode)

                    });
            }

            ViewBag.postCodeList = postCodeList;

            return View(UserViewEmptyGardensinLocation(pcode));
        }

        // GET: Garden/Details/5
        [HttpGet]
        public ActionResult GardenDetails(string pcode)
        {
            return View(_gardenService.GetGardenViewModel(pcode));
        }

        [HttpGet]
        public ActionResult GetAllocatedAllotment(int gardenid)
        {
            return View(_gardenService.GetAllocatedAllotment(gardenid));
        }

        // GET: Garden/Create
        [HttpGet]
        public ActionResult _addcropstogarden(string selectedCrop)
        {
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
            
            return PartialView();
        }

        // DS - Move to the admin controller
        // POST: Garden/Create
        [HttpGet]
        public ActionResult ConfirmCropsToGarden(Planted planted)
        {
            var userId = User.Identity.GetUserId();
            var userGarden = _gardenService.GetGardenFromUser(userId);
            try
            {
                // DS - Create a new object containing planted information
                Planted setPlanted = new Planted
                {
                    gardenId = userGarden.gardenId,
                    cropId = planted.cropId
                };

                // DS - Pass it to the method
                _gardenService.addcropstogarden(setPlanted);

                Planted lastPlanted = _gardenService.GetLastPlanted();

                var tends = _tendService.getTends();

                foreach (var tend in tends)
                {                    
                    Tended myTended = new Tended
                    {
                        cropId = planted.cropId,
                        tendId = tend.tendId,
                        Date = DateTime.Now,
                        plantedId = lastPlanted.plantedId
                    };

                    _tendService.setAsTended(myTended);
                }

                return RedirectToAction("ListSelectedCrops", new { controller = "Garden" });
            }
            catch
            {
                return View();
            }
        }
    }
}
