﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PingPakistan.DataAccess.Context
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ping_pakistanEntities : DbContext
    {
        public ping_pakistanEntities()
            : base("name=ping_pakistanEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<categories> categories { get; set; }
        public virtual DbSet<cities> cities { get; set; }
        public virtual DbSet<city_areas> city_areas { get; set; }
        public virtual DbSet<posts> posts { get; set; }
        public virtual DbSet<users> users { get; set; }
    }
}
