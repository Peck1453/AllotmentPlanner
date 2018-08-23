using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllotmentPlanner.Data.ViewModel
{
    public class CropMaintenanceViewModel
    {
        [Display(Name = "Crop Id Number")]
        public int cropId { get; set; }
        [Display(Name = "Tend Id Number")]
        public int tendId { get; set; }
        [Display(Name = "Planted Id Number")]
        public int plantedId { get; set; }
        [Display(Name = "Tended Id Number")]
        public int tendedId { get; set; }
        [Display(Name = "Crop Name")]
        public string cropName { get; set; }
        [Display(Name = "Tend Name")]
        public string tendName { get; set; }
        [Display(Name = "Water Frequecy (days)")]
        public int waterFrequency { get; set; }
        [Display(Name = "Tend Frequecy (days)")]
        public int? tendFrequency { get; set; }
        [Display(Name = "Date of Tend")]
        public DateTime? Date { get; set; }
        [Display(Name = "Garden Id Number")]
        public int gardenId { get; set; }
        public CropMaintenanceViewModel() { }



    }
}
