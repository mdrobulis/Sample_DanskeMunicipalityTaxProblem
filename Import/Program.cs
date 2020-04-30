using System;
using service.Services;

namespace Import
{
    class Program
    {
        static void Main(string[] args)
        {
            var io = new FileDataProvider(args[0]);
            var repo = new TaxRepository();

            var records =io.GetTaxRecords();

            foreach (var item in records)
            {
                item.ID=null;
                repo.Create(item);                
            }


        }
    }
}
