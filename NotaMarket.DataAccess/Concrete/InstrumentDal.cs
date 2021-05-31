using Microsoft.EntityFrameworkCore;
using NotaMarket.DataAccess.Abstract;
using NotaMarket.DataAccess.Context;
using NotaMarket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaMarket.DataAccess.Concrete
{
    public class InstrumentDal : GenericRepository<Instrument, ApplicationDbContext>, IInstrumentDal
    {
        private ApplicationDbContext _db;

        public InstrumentDal(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Instrument> GetInstrumentsWithType()
        {
            return _db.Instruments.Include(x => x.InstrumentType).ToList();
        }

        public List<Instrument> GetLimitedInstrumentsWithType(int count)
        {
            return _db.Instruments.Include(x => x.InstrumentType).Take(count).ToList();
        }
    }
}
