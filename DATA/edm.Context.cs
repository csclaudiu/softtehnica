﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DATA
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class softtehnicaEntities : DbContext
    {
        public softtehnicaEntities()
            : base("name=softtehnicaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<client> clients { get; set; }
        public virtual DbSet<order> orders { get; set; }
        public virtual DbSet<orderitem> orderitems { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<location> locations { get; set; }
        public virtual DbSet<v_OrderProducts> v_OrderProducts { get; set; }
        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<v_OrderTotals> v_OrderTotals { get; set; }
        public virtual DbSet<v_ClientGlobalActivity> v_ClientGlobalActivity { get; set; }
        public virtual DbSet<v_ClientLocationActivity> v_ClientLocationActivity { get; set; }
    }
}
