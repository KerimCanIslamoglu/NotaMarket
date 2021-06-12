using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotaMarket.Api.Model.SheetMusic
{
    public class CreateSheetMusicModel
    {
        public int Id { get; set; }
        public string SheetMusicName { get; set; }
        public string Description { get; set; }
        public string SheetUrl { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

        public int ComposerId { get; set; }

        public int InstrumentId { get; set; }
    }
}
