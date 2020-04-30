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
    public class MunicipalityController : ControllerBase
    {

        private readonly ILogger<TaxController> _logger;
        IDataProvider _data;

        public MunicipalityController(ILogger<TaxController> logger, IDataProvider data)
        {
            _logger = logger;

            _data = data;
        }

        [HttpGet("{municipality}")]
        public IEnumerable<TaxRecord> Post(string municipality)
        {
            try
            {
                return _data.GetTaxRecords().Where(x => x.Municipality == municipality);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"Error retriving municipality tax periods  ", new {municipality = municipality});
                throw new Exception("Error retriving municipality tax periods");
            }


        }
    }
}
