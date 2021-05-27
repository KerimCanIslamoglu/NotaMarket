using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotaMarket.Api.Model
{
    public class CreateInstrumentModel
    {
        public int Id { get; set; }
        public string InstrumentName { get; set; }
        public int InstrumentTypeId { get; set; }
    }
}
