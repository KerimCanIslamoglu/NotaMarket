using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaMarket.Entities
{
    public class Instrument
    {
        public int Id { get; set; }
        public string InstrumentName { get; set; }

        public int InstrumentTypeId { get; set; }
        public InstrumentType InstrumentType { get; set; }
        public ICollection<SheetMusic> SheetMusic { get; set; }

    }
}
