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
       
        public IEnumerable<TaxRecord> GetTaxRexords()
        {
            
            TextReader reader = new StreamReader(sourceFile);
            var csvReader = new CsvReader(reader,CultureInfo.InvariantCulture);
            var records = csvReader.GetRecords<TaxRecord>();
            return records;            
        }
    }    
}