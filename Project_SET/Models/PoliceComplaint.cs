//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project_SET.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class PoliceComplaint
    {
        [Display(Name ="CNIC Number : ")]
        public long CNIC_NO { get; set; }

        [Display(Name ="Full Name : ")]
        public string NAME { get; set; }

        [Display(Name ="CNIC Address : ")]
        public string CNIC_ADDRESS { get; set; }

        [Display(Name ="Area : ")]
        public string AREA { get; set; }

        [Display(Name ="Complaint : ")]
        [DataType(DataType.MultilineText)]
        public string COMPLAINT { get; set; }
        public Nullable<long> S_NO { get; set; }

        [Display(Name = "Department : ")]
        public virtual Department Department { get; set; }
    }
}
