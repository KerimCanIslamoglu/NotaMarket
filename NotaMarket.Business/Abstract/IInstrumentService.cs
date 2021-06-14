using NotaMarket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaMarket.Business.Abstract
{
    public interface IInstrumentService
    {
        List<Instrument> GetInstruments();
        List<Instrument> GetLimitedInstruments(int count);
        Instrument GetInstrumentById(int id);
        void CreateInstrument(Instrument instrument);
        void UpdateInstrument(Instrument instrument);
        void DeleteInstrument(Instrument instrument);
    }
}
