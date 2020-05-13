using System;
using service.Interfaces;
using service.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace service.Services
{
    public class TaxDB : DbContext
    {        

        public TaxDB()
        {           
        }

        public DbSet<TaxRecord> TaxPeriods { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
           string path = System.IO.Path.Combine(
                System.Environment.CurrentDirectory, "TaxDB.db");
            optionsBuilder.UseSqlite($"Filename={path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {                          
           modelBuilder.Entity<TaxRecord>().HasKey(x=>x.ID);
        }

    }

}