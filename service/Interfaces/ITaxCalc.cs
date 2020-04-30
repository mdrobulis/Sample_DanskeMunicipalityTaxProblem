using service.Data;
using System.Collections.Generic;
namespace service.Interfaces
{
    public interface ITaxCalc {

        public double Calculate(IEnumerable<TaxRecord> data, TaxRequest request);

    }
    
}