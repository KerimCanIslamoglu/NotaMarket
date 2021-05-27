using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaMarket.Entities
{
    public class InstrumentType
    {
        public int Id { get; set; }
        public string InstrumentTypeName { get; set; }

        public ICollection<Instrument> Instruments { get; set; }
    }
}
