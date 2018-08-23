using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllotmentPlanner.Data.ViewModel
{
    public class CropDataViewModel
    {
        [Display(Name = "Crop Id")]
        public int CropId { get; set; }

        [Display(Name = "Crop Name")]
        public string CropName { get; set; }

        [Display(Name = "Amount of Space seed requires (sq in)")]
        public int SpaceRequired { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Earliest Planting Date")]
        //[Required(ErrorMessage = "Please enter a date the promo code will expire")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EarlyPlanting { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Latest Planting Date")]
        //[Required(ErrorMessage = "Please enter a date the promo code will expire")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime LatePlanting { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Earliest Harvest Date")]
        //[Required(ErrorMessage = "Please enter a date the promo code will expire")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime EarlyHarvest { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Latest Harvest Date")]
        //[Required(ErrorMessage = "Please enter a date the promo code will expire")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime LateHarvest { get; set; }

        [Display(Name = "Time for Crop to Grow (days)")]
        public int? growthTime { get; set; }
        [Display(Name = "Bird Netting required")]
        public bool birdNetting { get; set; }
        [Display(Name = "slug Pellets required?")]
        public bool slugPellets { get; set; }
        [Display(Name = "Feed required?")]
        public bool Feed { get; set; }
        [Display(Name = "Watering Interval (days)")]
        public int? wateringInterval { get; set; }

        public CropDataViewModel() { }

    }
}
