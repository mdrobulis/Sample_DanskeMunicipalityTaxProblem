using System;
using service.Interfaces;
using service.Data;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using System.Text;
using System.Globalization;

namespace service.Services
{
    public class DatabaseDataProvider:IDataProvider
    {   
       
        public IEnumerable<TaxRecord> GetTaxRexords()
        {
            using (var db = new TaxDB())
            {
                return new List<TaxRecord>(db.TaxPeriods);                
            }
        }
    }
    
}