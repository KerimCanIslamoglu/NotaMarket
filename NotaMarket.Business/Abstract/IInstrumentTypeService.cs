using Microsoft.AspNetCore.Http;
using NotaMarket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaMarket.Business.Abstract
{
    public interface IInstrumentTypeService
    {
        List<InstrumentType> GetInstrumentTypes();
        InstrumentType GetInstrumentTypeById(int id);
        void CreateInstrumentType(InstrumentType instrumentType);
        void UpdateInstrumentType(InstrumentType instrumentType);
        void DeleteInstrumentType(InstrumentType instrumentType);
    }
}
