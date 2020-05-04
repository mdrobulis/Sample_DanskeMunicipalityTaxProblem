using System;
using service.Interfaces;
using service.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;

namespace service.Services
{
    public class NativeTaxRepository : ITaxRecordRepository
    {
        ITimeProvider _time;
        public NativeTaxRepository(ITimeProvider time)
        {
            _time =time;
            
        }
        public TaxRecord Create(TaxRecord t)
        {
            using (var db = new TaxDB())
            {
                t.Created = _time.CurrentTime();                
                var res = db.TaxPeriods.Add(t);

                db.SaveChanges();
                return res.Entity;
            };

        }

        public void Delete(long id)
        {
            using (var db = new TaxDB())
            {                
                var r = db.TaxPeriods.Find(id);
                r.Deleted = _time.CurrentTime();                
                db.SaveChanges();
            };

        }

        public void Restore(long id)
        {
            using (var db = new TaxDB())
            {                
                var r = db.TaxPeriods.Find(id);
                r.Deleted = null;
                db.SaveChanges();
            };

        }

        public TaxRecord Retrieve(long id)
        {
            using (var db = new TaxDB())
            {
                return db.TaxPeriods.FromSqlRaw("select * from TaxPeriods t Where t.ID={0} and t.Deleted is not null ",id).Single();
            }
        }

        public IEnumerable<TaxRecord> RetrieveAll()
        {
            using (var db = new TaxDB())
            {                
                return db.TaxPeriods.FromSqlRaw("select * from TaxPeriods t where t.Deleted is not null").ToList();
            }
        }

        public IEnumerable<TaxRecord> RetrieveByMunicipality(string municipality)
        {
            using (var db = new TaxDB())
            {
                return db.TaxPeriods.FromSqlRaw("select * from TaxPeriods t where t.Municipality={0} and t.Deleted is not null", municipality).ToList();
            }
        }


        public TaxRecord Update(TaxRecord r)
        {
            using (var db = new TaxDB())
            {                
                r.Modified = _time.CurrentTime();
                var res =db.Update(r);
                db.SaveChanges();
                return res.Entity;


            }

        }
    }
}