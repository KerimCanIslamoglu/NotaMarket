using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NotaMarket.UI.Abstract;
using NotaMarket.UI.Models;
using NotaMarket.UI.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NotaMarket.UI.Controllers
{
    public class HomeController : Controller
    {
        private IInstrumentBusiness _instrumentBusiness;
        private ISheetMusicBusiness _sheetMusicBusiness;

        public HomeController(IInstrumentBusiness instrumentBusiness, ISheetMusicBusiness sheetMusicBusiness)
        {
            _instrumentBusiness = instrumentBusiness;
            _sheetMusicBusiness = sheetMusicBusiness;
        }

        public async Task<IActionResult> Index()
        {
            var instruments = await _instrumentBusiness.GetHomePageInstrumentsFromApi(3);
            var sheetMusics = await _sheetMusicBusiness.GetLimitedSheetMusicsFromApi(6);

            var model = new HomePageDto();
            model.InstrumentModels = new List<InstrumentModel>();
            model.SheetMusicModels = new List<SheetMusicModel>();

            model.InstrumentModels.AddRange(instruments.Response);
            model.SheetMusicModels.AddRange(sheetMusics.Response);

            return View(model);
        }
    }
}
