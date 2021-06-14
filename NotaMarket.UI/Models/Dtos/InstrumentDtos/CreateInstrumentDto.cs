using Microsoft.AspNetCore.Http;
using NotaMarket.UI.Models.Dtos.InstrumentTypeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotaMarket.UI.Models.Dtos.InstrumentDtos
{
    public class CreateInstrumentDto
    {
        public string InstrumentName { get; set; }
        public int InstrumentTypeId { get; set; }
        public List<InstrumentTypeDto> InstrumentTypes { get; set; }
        public IFormFile FormFile { get; set; }

    }
}
