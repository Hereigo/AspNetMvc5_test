﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AspNetMvc_5
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Andrew2Context : DbContext
    {
        public Andrew2Context()
            : base("name=Andrew2Context")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BILLS> BILLS { get; set; }
        public virtual DbSet<CONTRAGENTS> CONTRAGENTS { get; set; }
        public virtual DbSet<PERIODS> PERIODS { get; set; }
        public virtual DbSet<TYPESOFDOC> TYPESOFDOC { get; set; }
    }
}