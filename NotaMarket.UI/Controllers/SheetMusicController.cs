using Microsoft.AspNetCore.Mvc;
using NotaMarket.UI.Abstract;
using NotaMarket.UI.ApiHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotaMarket.UI.Controllers
{
    public class SheetMusicController : Controller
    {
        private IInstrumentBusiness _instrumentBusiness;

        public SheetMusicController(IInstrumentBusiness instrumentBusiness)
        {
            _instrumentBusiness = instrumentBusiness;
        }

        public async Task<IActionResult> Index()
        {
            var instruments =await _instrumentBusiness.GetInstrumentsFromApi();

            return View(instruments);
        }
    }
}
