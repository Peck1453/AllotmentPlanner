using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllotmentPlanner.Data.ViewModel
{
    public class UserGardenViewModel
    {
        public int cropId { get; set; }
        public int gardenId { get; set; }
        public string cropName { get; set; }
        public int? growthTime { get; set; }
        public DateTime? dateIn { get; set; }
        public DateTime? dateOut { get; set; }
        public int cropSize { get; set; }
        public DateTime earliestPlant { get; set; }
        public DateTime latestPlant { get; set; }
        public DateTime earliestHarvest { get; set; }
        public DateTime? estimatedHarvestDate { get; set; }
        public DateTime lastestHarvest { get; set; }



    }
}
