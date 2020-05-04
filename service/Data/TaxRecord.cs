using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace service.Data
{
  
    [Table("TaxPeriods")]
    public class TaxRecord
    {
      
      public long? ID {get;set;}
      public string Municipality {get;set;}

      public DateTime Start {get;set;}   
      public DateTime End {get;set;}   
      public double TaxRate {get;set;}

      public DateTime Created {get;set;}   
      public DateTime? Modified {get;set;}
      public DateTime? Deleted {get;set;}


    }
    
}