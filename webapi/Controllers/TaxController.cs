using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using service.Interfaces;
using service.Data;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxController : ControllerBase
    {
        
        private readonly ILogger<TaxController> _logger;
         IDataProvider _data;
         ITaxCalc _calc;

        public TaxController(ILogger<TaxController> logger, IDataProvider data, ITaxCalc calc )
        {
            _logger = logger;
            _calc = calc;
            _data = data;
        }

        [HttpPost]
        public TaxResponse Post(TaxRequest request)
        { 
           try {

            
           //var request = new TaxRequest(){Municipality="Vilnius", Date= new DateTime(2016,5,2) };            
           var taxRate = _calc.Calculate(_data.GetTaxRecords(),request );           
           var resp = new TaxResponse(){Request = request, TaxRate = taxRate };
           return resp;

           }catch(Exception ex)
           {
               _logger.LogError(ex,"Error Calculating tax rate", new {request= request});
               throw new Exception("Error Calculating tax rate");
           }

           
        }
    }
}
