using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotaMarket.Api.Model
{
    public class CreateSheetMusicModel
    {
        public int Id { get; set; }
        public string SheetMusicName { get; set; }
        public string Description { get; set; }
        public string SheetUrl { get; set; }
        public bool IsActive { get; set; }

        public int ComposerId { get; set; }

        public int InstrumentId { get; set; }
    }
}
