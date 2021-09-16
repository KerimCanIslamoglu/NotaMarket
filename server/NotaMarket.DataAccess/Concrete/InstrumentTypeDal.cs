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
    public class InstrumentTypeDal : GenericRepository<InstrumentType, ApplicationDbContext>, IInstrumentTypeDal
    {
        private ApplicationDbContext _db;

        public InstrumentTypeDal(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<InstrumentType> GetInstrumentTypesWithInstrument()
        {
            return _db.InstrumentTypes.Include(x => x.Instruments).ToList();
        }
    }
}
