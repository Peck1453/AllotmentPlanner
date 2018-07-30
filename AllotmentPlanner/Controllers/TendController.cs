using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using AllotmentPlanner.Data.ViewModel;
using System.Collections;

namespace AllotmentPlanner.Controllers
{
    public class TendController : ApplicationController
    {
        // GET: Tend
        [HttpGet]
        public ActionResult Tends()
        {
            return View(_tendService.getTends());
        }

        // DS - Are you using this?
        // GET: Tend/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult _getTendActions()
        {
            var userId = User.Identity.GetUserId();
            
            return View(_tendService.getTendActions(userId));
        }

        [HttpGet]
        public ActionResult _loopTends(int plantedId)
        {
            var userId = User.Identity.GetUserId();
            var tends = _tendService.loopTends(userId, plantedId);
            //var plantedCrop = _gardenService.getPlantedCrop(plantedId);

            List<CropMaintenanceViewModel> filteredList = new List<CropMaintenanceViewModel>();
            foreach (var item in tends)
            {
                // DS - Loop through each tend and if it meets the requirements, add it to the list

                // DS - if date is not null, use it, else take todays date and add 1 year so it appears in the future.
                DateTime tendDate = item.Date ?? DateTime.Now.AddYears(1);

                // DS - if tend frequency is not null, use it, else set it to 999
                // DS - This shouldn't be a nullable so when you change this, you can remove this bit of code and just pass item.tendFrequency to the next line.
                int frequency = item.tendFrequency ?? 999;

                DateTime tendDays = tendDate.AddDays(frequency);

                // DS - when today's date is greater than the 
                if (DateTime.Now > tendDays)
                {
                    filteredList.Add(item);
                }
            }

            return PartialView(filteredList);
        }
    }
}
