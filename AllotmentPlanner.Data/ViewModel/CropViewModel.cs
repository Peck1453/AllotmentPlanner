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

        public int CropId { get; set; }


        public string CropName { get; set; }

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
        public int? growthTime { get; set; }


        public bool birdNetting { get; set; }
        public bool slugPellets { get; set; }
        public bool Feed { get; set; }
        public bool Water { get; set; }

        public CropDataViewModel() { }

    }
}
