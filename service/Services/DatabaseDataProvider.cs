using System;
using service.Interfaces;
using service.Data;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using System.Text;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace service.Services
{
    public class DatabaseDataProvider:IDataProvider
    {   
       
        public IEnumerable<TaxRecord> GetTaxRecords()
        {
            using (var db = new TaxDB())
            {
                return new List<TaxRecord>(db.TaxPeriods);                
            }
        }

        public IEnumerable<TaxRecord> GetMunicipalityTaxRecords(string municipality)
        {
             using (var db = new TaxDB())
            {
                return db.TaxPeriods.FromSqlRaw("select * from TaxPeriods t where t.Municipality={0} and t.Deleted is null", municipality).ToList();
            }
        }
    }
    
}