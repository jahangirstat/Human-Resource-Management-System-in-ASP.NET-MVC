﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCFinalProject.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MVC4ProjectEntities2 : DbContext
    {
        public MVC4ProjectEntities2()
            : base("name=MVC4ProjectEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Attendence> Attendences { get; set; }
        public virtual DbSet<Benefit> Benefits { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }
        public virtual DbSet<Division> Divisions { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Employee_Type> Employee_Type { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<Promotion> Promotions { get; set; }
        public virtual DbSet<SalaryHead> SalaryHeads { get; set; }
        public virtual DbSet<SalaryHistory> SalaryHistories { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<Transfer_Info> Transfer_Info { get; set; }
    }
}
