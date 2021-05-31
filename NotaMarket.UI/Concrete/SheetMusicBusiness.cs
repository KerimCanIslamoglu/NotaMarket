using Microsoft.Extensions.Configuration;
using NotaMarket.UI.Abstract;
using NotaMarket.UI.ApiHelper;
using NotaMarket.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotaMarket.UI.Concrete
{
    public class SheetMusicBusiness : ISheetMusicBusiness
    {
        private IRestApiGenerator _restApiGenerator;
        private readonly IConfiguration _config;

        public SheetMusicBusiness(IRestApiGenerator restApiGenerator, IConfiguration config)
        {
            _restApiGenerator = restApiGenerator;
            _config = config;
        }

        public async Task<ResponseListModel<SheetMusicModel>> GetSheetMusicsFromApi()
        {
            string url = _config.GetValue<string>("ApiUrl") + "SheetMusic/GetSheetMusic";
            var sheetMusics = await _restApiGenerator.GetApi<ResponseListModel<SheetMusicModel>>(url);

            return sheetMusics;
        }

        public async Task<ResponseListModel<SheetMusicModel>> GetLimitedSheetMusicsFromApi(int count)
        {
            string url = _config.GetValue<string>("ApiUrl") + "SheetMusic/GetLimitedSheetMusics/"+count;
            var sheetMusics = await _restApiGenerator.GetApi<ResponseListModel<SheetMusicModel>>(url);

            return sheetMusics;
        }
    }
}
