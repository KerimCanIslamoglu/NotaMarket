using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotaMarket.UI.Models.Dtos
{
    public class InstrumentSheetDto
    {
        public List<SheetMusicModel> SheetMusicModels { get; set; }
        public List<InstrumentModel> InstrumentModels { get; set; }
    }
}
