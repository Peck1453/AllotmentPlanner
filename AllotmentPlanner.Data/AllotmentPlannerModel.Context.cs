﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AllotmentEntities : DbContext
    {
        public AllotmentEntities()
            : base("name=AllotmentEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Allotment> Allotment { get; set; }
        public virtual DbSet<AllotmentAllocation> AllotmentAllocation { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Crop> Crop { get; set; }
        public virtual DbSet<Crop_Requirements> Crop_Requirements { get; set; }
        public virtual DbSet<CropHarvest> CropHarvest { get; set; }
        public virtual DbSet<GardenLocation> GardenLocation { get; set; }
        public virtual DbSet<Planted> Planted { get; set; }
        public virtual DbSet<Tended> Tended { get; set; }
        public virtual DbSet<TendType> TendType { get; set; }
        public virtual DbSet<CropRequirements> CropRequirements { get; set; }
    }
}
