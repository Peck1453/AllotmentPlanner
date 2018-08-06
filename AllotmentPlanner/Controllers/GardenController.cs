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

        public ActionResult GardensUserView()
        {
            return View(_gardenService.GetGardenLocations());
        }


        [HttpGet]
        public ActionResult ListSelectedCrops()
        {
            var userId = User.Identity.GetUserId();
            int countUserCrops = _gardenService.ListSelectedCrops(userId).Count();
            ViewBag.CountCrops = countUserCrops;
            ViewBag.NoCrops = "There are No Crops planned for your Garden! Select the button above to add a few";

            ViewBag.GardenCheck = _gardenService.CountUserActiveGardens(userId).Count();
            ViewBag.NoGarden = "You do not have a Garden Yet, please select one from the Dashboard";

            return View(_gardenService.ListSelectedCrops(userId));
        }

        [HttpGet]
        public ActionResult GetUserGarden()
        {
            var userId = User.Identity.GetUserId();

            ViewBag.GardenCheck = _gardenService.CountUserActiveGardens(userId).Count();
            ViewBag.NoGarden = "You do not have a Garden Yet, please select one from the Dashboard";


            int countUserCrops = _gardenService.ListSelectedCrops(userId).Count();
            ViewBag.CountCrops = countUserCrops;
            ViewBag.NoCrops = "There are No Crops planned for your Garden! Select the button above to add a few";

            return View(_gardenService.GetUserGarden(userId));
        }

        [HttpGet]
        public ActionResult ViewGardensinLocation(string pcode)
        {
            ViewBag.PostCode = pcode;
            ViewBag.LocationName = _gardenService.GetGardenLocation(pcode).Name;

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

    }
}
