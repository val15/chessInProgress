﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Chess.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ChessDBEntities : DbContext
    {
        public ChessDBEntities()
            : base("name=ChessDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<GamePart> GamePart { get; set; }
        public virtual DbSet<Turns> Turns { get; set; }
        public virtual DbSet<VBestPostions> VBestPostions { get; set; }
    }
}
