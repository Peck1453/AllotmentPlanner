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
        public ActionResult Tends()
        {
            return View(_tendService.getTends());
        }

        // GET: Tend/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        public ActionResult _getTendActions()
        {
            var userId = User.Identity.GetUserId();
            
            return View(_tendService.getTendActions(userId));
        }

        public ActionResult _loopTends(int plantedId)
        {
            var userId = User.Identity.GetUserId();
            //_tendService.loopTends(userId, plantedId);

            List<CropMaintenanceViewModel> filteredList = new List<CropMaintenanceViewModel>();

            var plantedCrop = _gardenService.getPlantedCrop(plantedId); // Get planted crop

            var tends = _tendService.loopTends(userId, plantedId);

            foreach (var item in tends)
            {
                if (DateTime.Now > Convert.ToDateTime(item.Date).AddDays(Convert.ToDouble(item.tendFrequency)) || item.Date == null) 
                  
            }


            return PartialView(filteredList);
        }
    }
}
