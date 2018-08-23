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
        [Required(ErrorMessage = "Please Enter Garden Post Code")]
        [Display(Name = "Garden Post Code")]
        public string  postCode { get; set; }
        [Required(ErrorMessage = "Please Enter Garden Name")]
        [Display(Name = "Garden Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Garden Owner")]
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
