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
    public class FileDataProvider:IDataProvider
    {
        string sourceFile;
        public FileDataProvider(string FileName)
        {
            sourceFile = FileName;
        }
       
        public IEnumerable<TaxRecord> GetTaxRecords()
        {
            
            TextReader reader = new StreamReader(sourceFile);
            var csvReader = new CsvReader(reader,CultureInfo.InvariantCulture);            
            // Config to set ID field to null for insertion to db
            csvReader.Configuration.HeaderValidated = null;
            csvReader.Configuration.MissingFieldFound = null;

            var records = csvReader.GetRecords<TaxRecord>();
            return records;            
        }
    }    
}