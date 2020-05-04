using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using service.Interfaces;
using service.Data;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxCalculatorController : ControllerBase
    {

        private readonly ILogger<TaxCalculatorController> _logger;
        IDataProvider _data;
        ITaxCalculator _calc;
        

        public TaxCalculatorController(ILogger<TaxCalculatorController> logger, IDataProvider data, ITaxCalculator calc)
        {
            _logger = logger;
            _calc = calc;
            _data = data;
            
        }

        [HttpGet]
        public TaxResponse Get(TaxRequest request)
        {
            try
            {
                var taxRate = _calc.Calculate(_data.GetMunicipalityTaxRecords(request.Municipality), request);
                var resp = new TaxResponse() { Request = request, TaxRate = taxRate };
                return resp;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Calculating tax rate", new { request = request });
                throw new Exception("Error Calculating tax rate");
            }


        }
    }
}
