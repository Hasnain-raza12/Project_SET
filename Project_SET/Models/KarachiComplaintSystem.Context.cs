﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Karachi_Complaint_SystemEntities2 : DbContext
    {
        public Karachi_Complaint_SystemEntities2()
            : base("name=Karachi_Complaint_SystemEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<IncomeTaxComplaint> IncomeTaxComplaints { get; set; }
        public virtual DbSet<KelectricComplaint> KelectricComplaints { get; set; }
        public virtual DbSet<PoliceComplaint> PoliceComplaints { get; set; }
        public virtual DbSet<SuigasComplaint> SuigasComplaints { get; set; }
        public virtual DbSet<WaterAndSewerageComplaint> WaterAndSewerageComplaints { get; set; }
    }
}