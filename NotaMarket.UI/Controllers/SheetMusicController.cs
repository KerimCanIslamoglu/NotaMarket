using Microsoft.AspNetCore.Mvc;
using NotaMarket.UI.Abstract;
using NotaMarket.UI.ApiHelper;
using NotaMarket.UI.Models;
using NotaMarket.UI.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotaMarket.UI.Controllers
{
    public class SheetMusicController : Controller
    {
        private IInstrumentBusiness _instrumentBusiness;
        private ISheetMusicBusiness _sheetMusicBusiness;

        public SheetMusicController(IInstrumentBusiness instrumentBusiness, ISheetMusicBusiness sheetMusicBusiness)
        {
            _instrumentBusiness = instrumentBusiness;
            _sheetMusicBusiness = sheetMusicBusiness;
        }

        public async Task<IActionResult> Index()
        {
            var model = new InstrumentSheetDto();
            var instruments =await _instrumentBusiness.GetInstrumentsFromApi();
            var sheetMusic = await _sheetMusicBusiness.GetSheetMusicsFromApi();

            model.InstrumentModels = new List<InstrumentModel>();
            model.SheetMusicModels = new List<SheetMusicModel>();

            model.InstrumentModels.AddRange(instruments.Response);
            model.SheetMusicModels.AddRange(sheetMusic.Response);

            return View(model);
        }
    }
}
