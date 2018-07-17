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
    public class GardenAdminController : ApplicationController

    {
        private AllotmentPlanner.Models.ApplicationDbContext _context;


        public GardenAdminController()
        {
            _context = new AllotmentPlanner.Models.ApplicationDbContext();

        }
        // GET: GardenAdmin
        public ActionResult Index()
        {
            return View();
        }

        // GET: GardenAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        // GET: CropAdmin/Create
        [HttpGet]
        public ActionResult AddGardenLocation()
        {
            return View();
        }

        // POST: CropAdmin/Create
        [HttpPost]
        public ActionResult AddGardenLocation(GardenLocation garden, Allotment allotment)
        {

            try
            {
                _gardenService.addGardenLocation(garden, allotment);
                return RedirectToAction("Gardens", new { controller = "Garden" });
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult AddGardentoLocation(int id, GardenViewModel garden)
        {
            List<SelectListItem> postCodeList = new List<SelectListItem>();
            foreach (var location in _gardenService.GetGardenLocations())
            {
                postCodeList.Add(
                    new SelectListItem()
                    {
                        Text = location.postCode,
                        Value = location.postCode.ToString()

                    });

               
            }
            ViewBag.postCodeList = postCodeList;
            

            return View();
        }


        [HttpPost]
        public ActionResult AddGardentoLocation(Allotment allotment, AllotmentAllocation allotmentAllocation, GardenViewModel gardenViewModel)
        {
            try
            {
                
                AllotmentAllocation myallotmentAllocation = new AllotmentAllocation
                {
                    gardenId = allotment.gardenId
                    

                };
                _gardenService.addGardentoAllotment(allotment, myallotmentAllocation);
                return RedirectToAction("Gardens", new { controller = "Garden" });

            }
            catch
            {
                return View();
            }

        }

        [HttpGet]

        // GET: GardenAdmin/Edit/5
        public ActionResult EditGarden(string pcode)
        {
            return View(_gardenService.GetGardenViewModel(pcode));
        }

        // POST: GardenAdmin/Edit/5
        [HttpPost]
        public ActionResult EditGarden(string pcode, GardenViewModel gardenViewModel, Allotment allotment)
        {
            {
                try
                {

                    Allotment myAllotment = new Allotment
                    {
                        gardenId = gardenViewModel.gardenId,
                        size =     gardenViewModel.size,
                        postCode = gardenViewModel.postCode
                    };

                    _gardenService.editGarden(myAllotment);


                    return RedirectToAction("Gardens", new { controller = "Garden" });
                }
                catch
                {
                    return View();
                }
            }
        }
        [HttpGet]
        // GET: GardenAdmin/Edit/5
        public ActionResult editGardenLocation(int gardenid)
        {
            return View(_gardenService.GetAllotment(gardenid));
        }

        // POST: GardenAdmin/Edit/5
        [HttpPost]
        public ActionResult editGardenLocation(int gardenid, GardenViewModel gardenViewModel, GardenLocation location)
        {
            {
                try
                {
                    GardenLocation mygardenLocation = new GardenLocation
                    {
                        postCode = gardenViewModel.postCode,
                        Name = gardenViewModel.Name,
                        Owner = gardenViewModel.Owner
                    };

                    _gardenService.editGarden(mygardenLocation);


                    return RedirectToAction("Gardens", new { controller = "Garden" });
                }
                catch
                {
                    return View();
                }
            }
        }

        [HttpGet]
        public ActionResult AssignGardenertoGarden(int gardenId, string userId)
        {
         List<SelectListItem> gardenerList = new List<SelectListItem>();

            var userList = _context.Users.OrderBy(u => u.UserName)
                .ToList();

            string selectedUser = "";

            foreach (var user in userList)
            {
                gardenerList.Add(
                  new SelectListItem()
                  {
                      Text = user.UserName,
                      Value = user.Id.ToString(),
                      Selected = (user.UserName == (selectedUser) ? true : false)
                  });
            }

            ViewBag.GardenerList = gardenerList;

            return View(_gardenService.GetAllocatedAllotment(gardenId));
        }
        [HttpPost]
        public ActionResult AssignGardenertoGarden(int gardenId, AllotmentAllocation allotmentAllocation)
        {
            try
            {
                AllotmentAllocation myallotmentAllocation = new AllotmentAllocation
                {
                    userId = allotmentAllocation.userId,
                    gardenId = gardenId,
                    dateFrom = DateTime.Now
                };

                _gardenService.assignGardenerToGarden(myallotmentAllocation);
                return RedirectToAction("Gardens", new { controller = "Garden" });
            }
            catch
            {
                return View();
            }


        }
        [HttpGet]
        public ActionResult RemoveGardenerfromGarden(int gardenId)
        {
           
            return View( _gardenService.GetAllocatedAllotment(gardenId));

        }
        [HttpPost]
        public ActionResult RemoveGardenerfromGarden(int gardenId, AllotmentAllocation allotmentAllocation, GardenViewModel gardenViewModel)
        {

            //try
            //{
                AllotmentAllocation myallotmentAllocation = new AllotmentAllocation
                {
                    gardenId =gardenId,
                    dateTo = DateTime.Now
                };

                _gardenService.removeGardenerFromGarden(myallotmentAllocation);
                return RedirectToAction("Gardens", new { controller = "Garden" });
            //}
            //catch
            //{
            //    return View();
            //}
        }
        // GET: GardenAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GardenAdmin/Delete/5
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
