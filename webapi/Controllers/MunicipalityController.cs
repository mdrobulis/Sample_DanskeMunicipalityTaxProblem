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

        private readonly ILogger<MunicipalityController> _logger;
        private readonly IDataProvider _data;
        private readonly IDataViewMapper _mapper;

        public MunicipalityController(ILogger<MunicipalityController> logger, IDataProvider data, IDataViewMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _data = data;
        }

        [HttpGet("{municipality}")]
        public IEnumerable<TaxRecordView> Get(string municipality)
        {
            try
            {
                return _data.GetMunicipalityTaxRecords(municipality).Select(_mapper.TaxRecordToView);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"Error retriving municipality tax periods  ", new {municipality = municipality});
                throw new Exception("Error retriving municipality tax periods");
            }


        }
    }
}
