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
        [Display(Name = "Garden Post Code")]
        public string  postCode { get; set; }
        [Display(Name = "Garden Name")]
        public string Name { get; set; }
        [Display(Name = "Garden Location Owner")]
        public string Owner { get; set; }
        [Display(Name = "Garden Id Number")]
        public int gardenId { get; set; }
        [Display(Name = "Assigned Gardener")]
        public string AssignedGardener { get; set; }
        [Display(Name = "Garden Size (sq ft)")]
        public int size { get; set; }
        [Display(Name = "Is the Garden Active?")]
        public bool Active { get; set; }
        public GardenViewModel() { }

    }
}
