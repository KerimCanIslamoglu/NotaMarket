using NotaMarket.UI.Models.InstrumentModels;
using NotaMarket.UI.Models.SheetMusicModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotaMarket.UI.Models.Dtos.HomeDtos
{
    public class HomePageDto
    {
        public List<InstrumentModel> InstrumentModels { get; set; }
        public List<SheetMusicModel> SheetMusicModels { get; set; }
    }
}
