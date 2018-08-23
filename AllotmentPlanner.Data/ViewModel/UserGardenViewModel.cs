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
        [Display(Name = "Crop Id")]
        public int cropId { get; set; }
        [Display(Name = "Garden Id")]
        public int gardenId { get; set; }
        [Display(Name = "Planted Id")]
        public int plantedId { get; set; }
        [Display(Name = "Crop Name")]
        public string cropName { get; set; }
        [Display(Name = "Growth time (days)")]
        public int? growthTime { get; set; }
        [Display(Name = "Crop Planted Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? dateIn { get; set; }
        [Display(Name = "Date Crop was Harvested")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? dateOut { get; set; }
        [Display(Name = "Space required Per Seed (Sq in)")]
        public int cropSize { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Earliest Planting Date")]
        public DateTime earliestPlant { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Latest Planting Date")]
        public DateTime latestPlant { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Earliest Harvest Date")]
        public DateTime earliestHarvest { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Estimsated Harvest Date")]
        public DateTime? estimatedHarvestDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime lastestHarvest { get; set; }

        //public UserGardenViewModel() {

        //}


    }
}
