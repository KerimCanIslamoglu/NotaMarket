using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotaMarket.UI.Controllers
{
    public class AdminMusicianController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
