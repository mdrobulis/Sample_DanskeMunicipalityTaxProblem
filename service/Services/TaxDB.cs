using System;
using service.Interfaces;
using service.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace service.Services
{
    public class TaxDB : DbContext
    {

        public DbSet<TaxRecord> TaxPeriods { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = System.IO.Path.Combine(
            System.Environment.CurrentDirectory, "TaxPeriods.db");
            optionsBuilder.UseSqlite($"Filename={path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {                          
           modelBuilder.Entity<TaxRecord>().HasKey(x=>x.ID);
           modelBuilder.Entity<TaxRecord>().HasData(new TaxRecord{Municipality="Vilnius", ID=1,Start=new DateTime(2016,1,1),End = new DateTime(2016,12,31),TaxRate=0.1});
          
        }

    }

}