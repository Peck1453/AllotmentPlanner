using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using AllotmentPlanner.Data;
using AllotmentPlanner.Data.ViewModel;
using System.Collections;

namespace AllotmentPlanner.Controllers
{
    public class TendController : ApplicationController
    {
        [HttpGet]
        public ActionResult Tends()
        {
            return View(_tendService.getTends());
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
            var tendTypes = _tendService.getTends();

            List<CropMaintenanceViewModel> filteredList = new List<CropMaintenanceViewModel>();
            foreach (var type in tendTypes)
            {
                var recentTend = _tendService.GetRecentTend(type.tendId, plantedId);
                int frequency = recentTend.tendFrequency ?? 0;

                bool needsTending = recentTend.Date < DateTime.Now.AddDays(-frequency);

                if (needsTending == true)
                 filteredList.Add(recentTend);
            }

            return PartialView(filteredList);
        }
    }
}
