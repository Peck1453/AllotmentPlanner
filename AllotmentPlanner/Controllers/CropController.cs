using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllotmentPlanner.Controllers
{
    public class CropController : ApplicationController
    {                
        // GET: Crop
        [HttpGet]
        public ActionResult Crops()
        {
            return View(_cropService.GetCrops());
        }

        // GET: Crop/Details/5        
        [HttpGet]
        public ActionResult CropDetails(int id)
        {            
            return View(_cropService.GetCropViewModel(id));
        }
    }
}
