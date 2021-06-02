using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotaMarket.UI.Models.Dtos
{
    public class InstrumentTypeDto
    {
        public int Id { get; set; }
        public string InstrumentTypeName { get; set; }
        public string PhotoUrl { get; set; }
    }
}
