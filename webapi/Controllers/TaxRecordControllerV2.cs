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
    [Route("v2/[controller]")]
    public class TaxRecordControllerV2 : ControllerBase
    {
        private readonly ILogger<TaxRecordControllerV2> _logger;
        private readonly ITaxRecordRepository _repo;
        private readonly IDataViewMapper _mapper;

        public TaxRecordControllerV2(ILogger<TaxRecordControllerV2> logger, ITaxRecordRepository repo, IDataViewMapper mapper )
        {
            _logger = logger;
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPut]
        public IActionResult AddNewTaxRecord(TaxRecordView view)
        {
            var record = _mapper.ViewToTaxRecord(view);
            _repo.Create(record);
            return new StatusCodeResult(200);
        }

        [HttpGet]
        public IEnumerable<TaxRecordView> GetAll()
        {
            return _repo.RetrieveAll().Select(_mapper.TaxRecordToView);
        }

        [HttpGet("{id:Long}")]
        public TaxRecordView GetOne(long id)
        {
            return _mapper.TaxRecordToView(_repo.Retrieve(id));
        }

        [HttpPost]
        public IActionResult Update(TaxRecordView view)
        {
            _repo.Update(_mapper.ViewToTaxRecord(view));
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
