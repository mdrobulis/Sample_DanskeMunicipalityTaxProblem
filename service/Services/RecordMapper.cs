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
    public class RecordMapper : IDataViewMapper
    {
        public TaxRecordView TaxRecordToView(TaxRecord r)
        {
            return new TaxRecordView()
            {
                Municipality = r.Municipality,
                Start = r.Start,
                End = r.End,
                TaxRate = r.TaxRate             
            };
        }

        public TaxRecord ViewToTaxRecord(TaxRecordView v)
        {
            return new TaxRecord()
            {
                ID = v.ID,
                Municipality = v.Municipality,
                Start = v.Start,
                End = v.End,
                TaxRate = v.TaxRate                                
            };
        }
    }
}