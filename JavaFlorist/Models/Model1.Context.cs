﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JavaFlorist.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class JavaFloristEntities : DbContext
    {
        public JavaFloristEntities()
            : base("name=JavaFloristEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BOUQUET> BOUQUETs { get; set; }
        public virtual DbSet<CART> CARTs { get; set; }
        public virtual DbSet<CUSTOMER> CUSTOMERs { get; set; }
        public virtual DbSet<OCCASION> OCCASIONs { get; set; }
        public virtual DbSet<ORDER> ORDERs { get; set; }
    }
}
