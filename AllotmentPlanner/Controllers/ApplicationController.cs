using AllotmentPlanner.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllotmentPlanner.Controllers
{
    public abstract class ApplicationController : Controller
    {
        public CropService _cropService;
        public TendService _tendService;

        public ApplicationController()
        {
            _cropService = new CropService();

            _tendService = new TendService();


        }
    }
}