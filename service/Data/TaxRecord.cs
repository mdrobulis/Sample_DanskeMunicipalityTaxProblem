using System;
namespace service.Data
{
    public class TaxRecord
    {
      
      public long? ID {get;set;}
      public string Municipality {get;set;}

      public DateTime Start {get;set;}   
      public DateTime End {get;set;}   
      public double TaxRate {get;set;}

    }
    
}