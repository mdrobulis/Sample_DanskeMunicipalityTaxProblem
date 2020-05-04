using System;
using service.Interfaces;
using service.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace service.Services
{
    public class TaxRepository : ITaxRecordRepository
    {

        DbContextOptions _options;
        public TaxRepository(DbContextOptions options)
        {
            _options=options;
        }

        public TaxRecord Create(TaxRecord t)
        {
            using (var db = new TaxDB())
            {
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
                db.TaxPeriods.Remove(r);
                db.SaveChanges();
            };

        }

        public TaxRecord Retrieve(long id)
        {
            using (var db = new TaxDB())
            {
                return db.TaxPeriods.Find(id);
            }
        }

        public IEnumerable<TaxRecord> RetrieveAll()
        {
            using (var db = new TaxDB())
            {
                return new List<TaxRecord>(db.TaxPeriods);
            }
        }

        public IEnumerable<TaxRecord> RetrieveByMunicipality(string municipality)
        {
            using (var db = new TaxDB())
            {
                return new List<TaxRecord>(db.TaxPeriods.AsQueryable().Where(x => x.Municipality == municipality));
            }
        }


        public TaxRecord Update(TaxRecord r)
        {
            using (var db = new TaxDB())
            {                
                var res =db.Update(r);
                db.SaveChanges();
                return res.Entity;


            }

        }
    }
}