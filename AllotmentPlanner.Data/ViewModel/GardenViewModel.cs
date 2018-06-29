using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllotmentPlanner.Data.ViewModel
{
    public class GardenViewModel
    {
        public string  postCode { get; set; }


        public string Name { get; set; }

        public string Owner { get; set; }


        public int gardenID { get; set; }

        public int size { get; set; }


        public GardenViewModel() { }

    }
}
