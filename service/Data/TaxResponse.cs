using System;
namespace service.Data
{
    public class TaxResponse
    {
        public TaxRequest Request{get;set;}

        public double TaxRate {get;set;}  
    }
    
}