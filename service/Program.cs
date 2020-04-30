using System;
using service.Interfaces;
using service.Services;
using Microsoft.EntityFrameworkCore;

namespace service
{
    class Program
    {
        static void Main(string[] args)
        {

            IDataProvider InitDataProvider = new FileDataProvider("../init.csv");
            using(var db = new TaxDB()){
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                db.TaxPeriods.AddRange(InitDataProvider.GetTaxRexords());
                db.SaveChanges();
            };

            IDataProvider dataProvider = new DatabaseDataProvider();
            ITaxCalc calc = new PeriodicTaxCalc();
            var res = calc.Calculate(dataProvider.GetTaxRexords(), new Data.TaxRequest(){Municipality="Vilnius", Date= new DateTime(2016,1,1) }  );
            Console.WriteLine(res);
            
             res = calc.Calculate(dataProvider.GetTaxRexords(), new Data.TaxRequest(){Municipality="Vilnius", Date= new DateTime(2016,5,2) }  );
            Console.WriteLine(res);
             res = calc.Calculate(dataProvider.GetTaxRexords(), new Data.TaxRequest(){Municipality="Vilnius", Date= new DateTime(2016,7,10) }  );
            Console.WriteLine(res);
             res = calc.Calculate(dataProvider.GetTaxRexords(), new Data.TaxRequest(){Municipality="Vilnius", Date= new DateTime(2016,3,16) }  );
            Console.WriteLine(res);

        }
    }
}
