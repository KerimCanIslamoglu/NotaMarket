using NotaMarket.Business.Abstract;
using NotaMarket.DataAccess.Abstract;
using NotaMarket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaMarket.Business.Concrete
{
    public class SheetMusicManager : ISheetMusicService
    {
        private ISheetMusicDal _sheetMusicDal;

        public SheetMusicManager(ISheetMusicDal sheetMusicDal)
        {
            _sheetMusicDal = sheetMusicDal;
        }

        public void CreateSheetMusic(SheetMusic sheetMusic)
        {
            _sheetMusicDal.Create(sheetMusic);
        }

        public List<SheetMusic> GetLimitedSheetMusics(int count)
        {
            return _sheetMusicDal.GetLimitedSheetMusicOrdered(count);
        }

        public List<SheetMusic> GetSheetMusics()
        {
            return _sheetMusicDal.GetAllSheetMusic();
        }
    }
}
