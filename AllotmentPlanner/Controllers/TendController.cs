using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;


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

        public ActionResult _loopTends()
        {
            var userId = User.Identity.GetUserId();
            return View(_tendService.loopTends(userId));

        }
    }
}
