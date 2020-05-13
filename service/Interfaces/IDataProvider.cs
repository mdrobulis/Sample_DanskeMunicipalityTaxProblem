using service.Data;
using System.Collections.Generic;

namespace service.Interfaces
{

    public interface IDataProvider {

        
        IEnumerable<TaxRecord> GetMunicipalityTaxRecords(string municipality);
        

    }
    
}