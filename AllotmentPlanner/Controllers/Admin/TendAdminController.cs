using AllotmentPlanner.Services.Service;
using AllotmentPlanner.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AllotmentPlanner.Data.ViewModel;

namespace AllotmentPlanner.Controllers.Admin
{
    public class TendAdminController : ApplicationController
    {
        // GET: TendAdmin
        public ActionResult Index()
        {
            return View();
        }

        // GET: TendAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [HttpGet]
        // GET: TendAdmin/Create
        public ActionResult AddTend()
        {
            return View();
        }

        // POST: TendAdmin/Create
        [HttpPost]
        public ActionResult AddTend(TendType tend)
        {
            //try
            //{
                _tendService.addTend(tend);

                return RedirectToAction("Tends", new { controller = "Tend" });
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: TendAdmin/Edit/5
        public ActionResult EditTend(int id)
        {
            return View(_tendService.getTend(id));
        }

        // POST: TendAdmin/Edit/5
        [HttpPost]
        public ActionResult EditTend(int id, TendType tend)
        {
            try
            {
                _tendService.editTend(tend);

                return RedirectToAction("Tends", new { controller = "Tend" });
            }
            catch
            {
                return View();
            }
        }

        // GET: TendAdmin/Delete/5
        public ActionResult DeleteTend(int id)
        {
            return View(_tendService.getTend(id));
        }

        // POST: TendAdmin/Delete/5
        [HttpPost]
        public ActionResult DeleteTend(int id, TendType tend)
        {
            //try
            //{
                TendType myTend = _tendService.getTend(id);
                _tendService.deleteTend(myTend);

                return RedirectToAction("Tends", new { controller = "Tend" });
            //}
            //catch
            //{
            //    return View();
            //}
        }
    }
}
