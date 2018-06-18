using System;
using System.Collections.Generic;
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

        public DateTime EarlyPlanting { get; set; }
        public DateTime LatePlanting { get; set; }
        public DateTime EarlyHarvest { get; set; }
        public DateTime LateHarvest { get; set; }
        public int? growthTime { get; set; }


        public bool? birdNetting { get; set; }
        public bool? slugPellets { get; set; }
        public bool? Feed { get; set; }
        public bool? Water { get; set; }

        public CropDataViewModel() { }

    }
}
