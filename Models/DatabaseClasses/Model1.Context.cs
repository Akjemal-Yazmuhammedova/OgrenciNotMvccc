﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OgrenciNotMvccc.Models.DatabaseClasses
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DbMvcOkulEntities2 : DbContext
    {
        public DbMvcOkulEntities2()
            : base("name=DbMvcOkulEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TBLDERSLER> TBLDERSLER { get; set; }
        public virtual DbSet<TBLKULUPLER> TBLKULUPLER { get; set; }
        public virtual DbSet<TBLNOTLAR> TBLNOTLAR { get; set; }
        public virtual DbSet<TBLOGRENCILER> TBLOGRENCILER { get; set; }
    }
}