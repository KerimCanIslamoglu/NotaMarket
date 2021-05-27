using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotaMarket.Api.Model
{
    public class InstrumentTypeModel
    {
        public int Id { get; set; }
        public string InstrumentTypeName { get; set; }

        public ICollection<InstrumentModel> Instruments { get; set; }
    }
}
