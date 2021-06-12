using NotaMarket.UI.Models;
using NotaMarket.UI.Models.SheetMusicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotaMarket.UI.Abstract
{
    public interface ISheetMusicBusiness
    {
        Task<ResponseListModel<SheetMusicModel>> GetSheetMusicsFromApi();
        Task<ResponseListModel<SheetMusicModel>> GetLimitedSheetMusicsFromApi(int count);
    }
}
