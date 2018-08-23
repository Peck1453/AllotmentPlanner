using AllotmentPlanner.Services.Service;
using AllotmentPlanner.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
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
        [Authorize(Roles = "Administrator")]
        // GET: CropAdmin/Create
        [HttpGet]
        public ActionResult AddGardenLocation()
        {
            return View();
        }

        // POST: CropAdmin/Create
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public ActionResult AddGardenLocation(GardenLocation garden, Allotment allotment)
        {
            try
            {
                _gardenService.addGardenLocation(garden, allotment);

                //Allocates the most recent garden
                _gardenService.AllocateGarden();


                return RedirectToAction("Gardens", new { controller = "Garden" });
            }
            catch (Exception ex)
            {
                // Might be worth looking at redirection to an error page
                ViewBag.Exception = ex;
                return View();
            }
        }

        [HttpGet]
        public ActionResult AddGardentoLocation()
        {
            List<SelectListItem> postCodeList = new List<SelectListItem>();
            foreach (var location in _gardenService.GetActiveGardenLocations())
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
        public ActionResult AddGardentoLocation(Allotment allotment)
        {
            try
            {
                // Adds a new garden to an allotment
                _gardenService.addGardentoAllotment(allotment);

                //Allocates the most recent garden
                _gardenService.AllocateGarden();

                return RedirectToAction("Gardens", new { controller = "Garden" });

            }
            catch (Exception ex)
            {
                //  Might be worth looking at redirection to an error page
                ViewBag.Exception = ex;
                return View();
            }
        }

        [HttpGet]
        // GET: GardenAdmin/Edit/5
        [Authorize(Roles = "Administrator")]

        public ActionResult EditGarden(string pcode)
        {
            return View(_gardenService.GetGardenViewModel(pcode));
        }

        // POST: GardenAdmin/Edit/5
        [HttpPost]
        [Authorize(Roles = "Administrator")]

        public ActionResult EditGarden(string pcode, GardenViewModel gardenViewModel, Allotment allotment)
        {
            try
            {
                Allotment myAllotment = new Allotment
                {
                    gardenId = gardenViewModel.gardenId,
                    size = gardenViewModel.size,
                    postCode = gardenViewModel.postCode
                };

                _gardenService.editGarden(myAllotment);
                
                return RedirectToAction("Gardens", new { controller = "Garden" });
            }
            catch (Exception ex)
            {
                //Might be worth looking at redirection to an error page
                ViewBag.Exception = ex;
                return View();
            }
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]

        // GET: GardenAdmin/Edit/5
        public ActionResult editGardenLocation(string pcode)
        {
            return View(_gardenService.GetGardenLocation(pcode));
        }

        // POST: GardenAdmin/Edit/5
        [HttpPost]
        [Authorize(Roles = "Administrator")]

        public ActionResult editGardenLocation(GardenLocation location)
        {
            {
                try
                {
                    GardenLocation mygardenLocation = new GardenLocation
                    {
                        postCode = location.postCode,
                        Name = location.Name,
                        Owner = location.Owner
                    };

                    _gardenService.editGardenLocation(mygardenLocation);
                    
                    return RedirectToAction("Gardens", new { controller = "Garden" });
                }
                catch (Exception ex)
                {
                    //  Might be worth looking at redirection to an error page
                    ViewBag.Exception = ex;
                    return View();
                }
            }
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]

        public ActionResult DeactivateGardenLocation(string pcode)
        {
           return View( _gardenService.GetGardenLocation(pcode));
        }


        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeactivateGardenLocation(GardenLocation location, string pcode)
        {

            GardenLocation gardenLocation = new GardenLocation
            {
                Active = false
            };

            _gardenService.DeactivateGardenLocation(location);

            var gardens = _gardenService.ListGardensbyPostCode(pcode);

            foreach (var garden in gardens)
                {
                AllotmentAllocation myAllotmentAllocation = new AllotmentAllocation
                {
                    dateTo = DateTime.Now

                };

                _gardenService.removeGardenerFromGarden(myAllotmentAllocation);

                }

            return RedirectToAction("Gardens", new { controller = "Garden" });



        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]

        public ActionResult AssignGardenertoGarden(int gardenId, string userId)
        {
            List<SelectListItem> gardenerList = new List<SelectListItem>();

            var userList = _context.Users.OrderBy(u => u.UserName).ToList();

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
        [Authorize(Roles = "Administrator")]

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
            catch (Exception ex)
            {
                //  Might be worth looking at redirection to an error page
                ViewBag.Exception = ex;
                return View();
            }
        }

        [HttpGet]
        public ActionResult AssignGardenertoGardenAsUser(int gardenId, AllotmentAllocation allotmentAllocation)
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
                return RedirectToAction("GetUserGarden", new { controller = "Garden" } );
            }
            catch (Exception ex)
            {
                //  Might be worth looking at redirection to an error page
                ViewBag.Exception = ex;
                return View();
            }
        }


        [Authorize(Roles = "Administrator")]

        [HttpGet]
        public ActionResult RemoveGardenerfromGarden(int gardenId)
        {           
            return View( _gardenService.GetAllocatedAllotment(gardenId));
        }

        [Authorize(Roles = "Administrator")]

        [HttpPost]
        public ActionResult RemoveGardenerfromGarden(int gardenId, AllotmentAllocation allotmentAllocation, GardenViewModel gardenViewModel)
        {
            try
            {
                AllotmentAllocation myallotmentAllocation = new AllotmentAllocation
                {
                    gardenId =gardenId,
                    dateTo = DateTime.Now
                };

                _gardenService.removeGardenerFromGarden(myallotmentAllocation);
                return RedirectToAction("Gardens", new { controller = "Garden" });
            }
            catch (Exception ex)
            {
                // Might be worth looking at redirection to an error page
                ViewBag.Exception = ex;
                return View();
            }
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

        // POST: Garden/Create
        [HttpGet]
        public ActionResult ConfirmCropsToGarden(Planted planted)
        {
            var userId = User.Identity.GetUserId();
            var userGarden = _gardenService.GetGardenFromUser(userId);
            try
            {
                // Create a new object containing planted information
                Planted setPlanted = new Planted
                {
                    gardenId = userGarden.gardenId,
                    cropId = planted.cropId
                };

                // Pass it to the method
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
            catch (Exception ex)
            {
                //  Might be worth looking at redirection to an error page
                ViewBag.Exception = ex;
                return View();
            }
        }

        [HttpGet]
        public ActionResult PlantCrop(int plantedId, Planted planted)
        {
            Planted myPlanted = new Planted
            {
                plantedId = planted.plantedId,
                dateIn = DateTime.Now
            };

            _gardenService.logCropAsPlanted(myPlanted);

            return RedirectToAction("GetUserGarden", new { controller = "Garden" });
        }

        [HttpGet]
        public ActionResult HarvestCrop(int PlantedId, Planted planted)
        {
            Planted myPlanted = new Planted
            {
                plantedId = planted.plantedId,
                dateOut = DateTime.Now
            };

            _gardenService.logCropAsHarvested(myPlanted);

            return RedirectToAction("GetUserGarden", new { controller = "Garden" });
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
            catch (Exception ex)
            {
                // Might be worth looking at redirection to an error page
                ViewBag.Exception = ex;
                return View();
            }
        }

        [HttpGet]
        public ActionResult RemovePlantedCrop(int plantedId, Planted planted)
        {

            Planted myPlanted = _gardenService.getPlantedCrop(plantedId);
            _gardenService.deletePlantedCrop(myPlanted);

            return RedirectToAction("ListSelectedCrops", new { controller = "Garden" });

        }
    }
}
