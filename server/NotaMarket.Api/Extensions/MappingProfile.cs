using AutoMapper;
using NotaMarket.Api.Model;
using NotaMarket.Api.Model.Composer;
using NotaMarket.Api.Model.SheetMusic;
using NotaMarket.Api.Model.Instrument;
using NotaMarket.Api.Model.InstrumentType;
using NotaMarket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotaMarket.Api.Extensions
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<InstrumentType, InstrumentTypeModel>().ReverseMap();
            CreateMap<InstrumentType, UpdateInstrumentTypeModel>().ReverseMap();
            CreateMap<InstrumentType, CreateInstrumentTypeModel>().ReverseMap();



            CreateMap<InstrumentModel, Instrument>()
               .ReverseMap()
               .ForMember(x => x.InstrumentTypeName, s => s.MapFrom(a => a.InstrumentType.InstrumentTypeName));
            CreateMap<Instrument, CreateInstrumentModel>().ReverseMap();
            CreateMap<Instrument, UpdateInstrumentModel>().ReverseMap();



            CreateMap<Composer, ComposerModel>().ReverseMap();




            CreateMap<SheetMusic, CreateSheetMusicModel>()
                .ReverseMap();





            CreateMap<SheetMusicModel, SheetMusic>()
                .ReverseMap()
                  .ForMember(x => x.ComposerName, s => s.MapFrom(a => a.Composer.ComposerName))
                  .ForMember(x => x.InstrumentName, s => s.MapFrom(a => a.Instruments.InstrumentName));


        }
    }
}
