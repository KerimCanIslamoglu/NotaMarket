using NotaMarket.Business.Abstract;
using NotaMarket.DataAccess.Abstract;
using NotaMarket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaMarket.Business.Concrete
{
    public class InstrumentManager : IInstrumentService
    {
        private IInstrumentDal _instrumentDal;

        public InstrumentManager(IInstrumentDal instrumentDal)
        {
            _instrumentDal = instrumentDal;
        }

        public Instrument GetInstrumentById(int id)
        {
            return _instrumentDal.GetInstrumentByIdWithType(id);
        }

        public List<Instrument> GetInstruments()
        {
            return _instrumentDal.GetInstrumentsWithType();
        }

        public List<Instrument> GetLimitedInstruments(int count)
        {
            return _instrumentDal.GetLimitedInstrumentsWithType(count);
        }

        public void UpdateInstrument(Instrument instrument)
        {
            _instrumentDal.Update(instrument);
        }
        public void CreateInstrument(Instrument instrument)
        {
            _instrumentDal.Create(instrument);
        }

        public void DeleteInstrument(Instrument instrument)
        {
            _instrumentDal.Delete(instrument);
        }
    }
}
