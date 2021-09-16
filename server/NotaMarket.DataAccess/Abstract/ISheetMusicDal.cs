using NotaMarket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaMarket.DataAccess.Abstract
{
    public interface ISheetMusicDal : IRepositoryBase<SheetMusic>
    {
        List<SheetMusic> GetAllSheetMusic();
        List<SheetMusic> GetLimitedSheetMusicOrdered(int count);
    }
}
