using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotaMarket.UI.Models.Dtos
{
    public class InstrumentDto
    {
        public int Id { get; set; }
        public string InstrumentName { get; set; }

        public int InstrumentTypeId { get; set; }
        public string InstrumentTypeName { get; set; }
    }
}
