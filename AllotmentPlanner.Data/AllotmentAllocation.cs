//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AllotmentPlanner.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    
    public partial class AllotmentAllocation
    {
        [Display(Name = "Allocation Id")]
        public int allocationId { get; set; }
        [Display(Name = "User Id")]
        public string userId { get; set; }
        [Display(Name = "Garden Id")]
        public int gardenId { get; set; }
        [Display(Name = "Allocation Start Date")]
        public Nullable<System.DateTime> dateFrom { get; set; }
        [Display(Name = "Allocation End Date")]
        public Nullable<System.DateTime> dateTo { get; set; }
    }
}
