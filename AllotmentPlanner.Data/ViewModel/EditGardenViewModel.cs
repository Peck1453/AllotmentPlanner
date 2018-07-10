using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllotmentPlanner.Data.ViewModel
{
    public class EditGardenViewModel
    {
        public int GardenId { get; set; }
        public int CropId { get; set; }
        public int GardenSize { get; set; }
        public string CropName { get; set; }
        public int CropSize { get; set; }
        public DateTime EarliestPlant { get; set; }
        public DateTime LatestPlant { get; set; }
        public DateTime EarliestHarvest{ get; set; }
        public DateTime LastestHarvest { get; set; }


        public EditGardenViewModel() { }

    }
}
