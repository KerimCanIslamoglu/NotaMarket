using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotaMarket.UI.Models.Dtos
{
    public class CreateInstrumentTypeDto
    {
        public string InstrumentTypeName { get; set; }
        public IFormFile FormFile { get; set; }
    }
}
