using AutoMapper;
using NotaMarket.UI.Models;
using NotaMarket.UI.Models.Dtos.InstrumentTypeDtos;
using NotaMarket.UI.Models.InstrumentTypeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotaMarket.UI.Extensions
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<InstrumentTypeModel, InstrumentTypeDto>().ReverseMap();
            CreateMap<InstrumentTypeModel, CreateInstrumentTypeModel>().ReverseMap();
            CreateMap<InstrumentTypeDto, CreateInstrumentTypeModel>().ReverseMap();
        }
    }
}
