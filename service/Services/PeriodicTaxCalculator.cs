using System;
using service.Interfaces;
using service.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace service.Services
{
    public class PeriodicTaxCalculator : ITaxCalculator
    {
        public double Calculate(IEnumerable<TaxRecord> municipalityData, TaxRequest request)
        {
            var taxes = ApplicableTaxes(municipalityData,request).OrderBy(x=>{ return x.End - x.Start;});

            // apply the shortest maching tax period
            return taxes.First().TaxRate;
        }

        private IEnumerable<TaxRecord> ApplicableTaxes(IEnumerable<TaxRecord> municipalityData, TaxRequest request){

            foreach (var period in municipalityData)
            {                
                if(request.Date >= period.Start && request.Date <= period.End)
                {
                    yield return period;
                }
                
            }
        }
    }

}