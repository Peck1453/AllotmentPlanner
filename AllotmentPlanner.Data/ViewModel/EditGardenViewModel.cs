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
        [Display(Name = "Garden Id")]
        public int gardenId { get; set; }
        [Display(Name = "Crop Id")]
        public int cropId { get; set; }
        [Display(Name = "Planted Id")]
        public int plantedId { get; set; }
        [Display(Name = "Size of Garden (sq ft)")]
        public int gardenSize { get; set; }
        [Display(Name = "Crop Name")]
        public string cropName { get; set; }
        [Display(Name = "Space Crop Seed Requires (sq in)")]
        public int cropSize { get; set; }
        [Display(Name = "Earliest Plant Date")]
        public DateTime earliestPlant { get; set; }
        [Display(Name = "Latest Plant Date")]
        public DateTime latestPlant { get; set; }
        [Display(Name = "Earliest Harvest Date")]
        public DateTime earliestHarvest{ get; set; }
        [Display(Name = "Lastest Harvest Date")]
        public DateTime lastestHarvest { get; set; }


        public EditGardenViewModel() { }

    }
}
