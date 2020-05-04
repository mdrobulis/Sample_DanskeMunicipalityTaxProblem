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

        

        public DbSet<TaxRecord> TaxPeriods { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            Console.WriteLine(ConfigurationManager.ConnectionStrings["MyConnection"].ToString());
            optionsBuilder.UseSqlite(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {                          
           modelBuilder.Entity<TaxRecord>().HasKey(x=>x.ID);
        }

    }

}