using System;
using service.Interfaces;
using service.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace service.Services
{
    public class PeriodicTaxCalc : ITaxCalc
    {
        public double Calculate(IEnumerable<TaxRecord> data, TaxRequest request)
        {
            var taxes = ApplicableTaxes(data,request).OrderBy(x=>{ return x.End - x.Start;});

            // apply the shortest maching tax period
            return taxes.First().TaxRate;
        }

        private IEnumerable<TaxRecord> ApplicableTaxes(IEnumerable<TaxRecord> data, TaxRequest request){

            foreach (var period in data.Where(x=>x.Municipality == request.Municipality))
            {                
                if(request.Date >= period.Start && request.Date <= period.End)
                {
                    yield return period;
                }
                
            }
        }
    }

}