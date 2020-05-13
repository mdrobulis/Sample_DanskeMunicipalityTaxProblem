using service.Data;
using System.Collections.Generic;

namespace service.Interfaces
{

    public interface IDataViewMapper {

        TaxRecordView TaxRecordToView(TaxRecord record);
        TaxRecord ViewToTaxRecord( TaxRecordView view);

    }
    
}