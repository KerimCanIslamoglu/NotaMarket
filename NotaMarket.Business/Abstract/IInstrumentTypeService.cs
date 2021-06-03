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
        void CreateInstrumentType(IFormFile file,InstrumentType instrumentType);
    }
}
