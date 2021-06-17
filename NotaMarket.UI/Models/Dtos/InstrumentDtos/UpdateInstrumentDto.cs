using Microsoft.AspNetCore.Http;
using NotaMarket.UI.Models.Dtos.InstrumentTypeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotaMarket.UI.Models.Dtos.InstrumentDtos
{
    public class UpdateInstrumentDto
    {
        public int Id { get; set; }
        public string InstrumentName { get; set; }
        public int InstrumentTypeId { get; set; }
        public List<InstrumentTypeDto> InstrumentTypes { get; set; }
        public IFormFile FormFile { get; set; }
        public string ImageString { get; set; }
    }
}
