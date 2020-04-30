
using service.Data;
using System.Collections.Generic;
namespace service.Interfaces
{

    public interface ITaxRecordRepository
    {
        TaxRecord Create(TaxRecord r);
        IEnumerable<TaxRecord> RetrieveAll();
        IEnumerable<TaxRecord> RetrieveByMunicipality(string municipality);
        TaxRecord Retrieve(long id);
        TaxRecord Update( TaxRecord r);
        void Delete(long id);
    }
}
