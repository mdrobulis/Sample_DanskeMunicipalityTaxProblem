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
    public class TaxRecordController : ControllerBase
    {

        private readonly ILogger<TaxController> _logger;
        private readonly ITaxRecordRepository _repo;

        public TaxRecordController(ILogger<TaxController> logger, ITaxRecordRepository repo )
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpPut]
        public IActionResult AddNewTaxRecord(TaxRecord record)
        {
            _repo.Create(record);
            return new StatusCodeResult(200);
        }

        [HttpGet]
        public IEnumerable<TaxRecord> GetAll()
        {
            return _repo.RetrieveAll();            
        }

        [HttpGet("{id:Long}")]
        public TaxRecord GetOne(long id)
        {
            return _repo.Retrieve(id); 
        }

        [HttpPost]
        public IActionResult Update(TaxRecord record)
        {
            _repo.Update(record);
            return new StatusCodeResult(200);
        }

        [HttpDelete("{id:long}")]
        public IActionResult Delete(long id)
        {
            _repo.Delete(id);
            return new StatusCodeResult(200);
        }
    }
}
