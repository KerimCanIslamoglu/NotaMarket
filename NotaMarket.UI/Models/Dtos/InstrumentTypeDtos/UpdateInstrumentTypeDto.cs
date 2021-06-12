using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotaMarket.UI.Models.Dtos.InstrumentTypeDtos
{
    public class UpdateInstrumentTypeDto
    {
        public int Id { get; set; }
        public string InstrumentTypeName { get; set; }
        public IFormFile FormFile { get; set; }
    }
}
