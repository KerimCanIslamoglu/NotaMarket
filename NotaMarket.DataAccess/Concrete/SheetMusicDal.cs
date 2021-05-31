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
    public class SheetMusicDal : GenericRepository<SheetMusic, ApplicationDbContext>, ISheetMusicDal
    {
        private ApplicationDbContext _db;

        public SheetMusicDal(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<SheetMusic> GetAllSheetMusic()
        {
            return _db.SheetMusics
                .Where(x=>x.IsActive==true)
                .Include(x => x.Composer)
                .Include(x => x.Instruments)
                .ToList();
        }

        public List<SheetMusic> GetLimitedSheetMusicOrdered(int count)
        {
            return _db.SheetMusics
               .Where(x => x.IsActive == true)
               .Include(x => x.Composer)
               .Include(x => x.Instruments)
               .OrderByDescending(x=>x.CreatedAt)
               .Take(count)
               .ToList();
        }
    }
}
