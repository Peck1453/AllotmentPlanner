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
        public int cropId { get; set; }
        public int tendId { get; set; }
        public int plantedId { get; set; }
        public int tendedId { get; set; }
        public string cropName { get; set; }
        public string tendName { get; set; }
        public int waterFrequency { get; set; }
        public int? tendFrequency { get; set; }
        public DateTime? Date { get; set; }
        public int gardenId { get; set; }
        public CropMaintenanceViewModel() { }



    }
}
