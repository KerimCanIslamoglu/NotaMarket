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

        public void CreateInstrument(Instrument instrument)
        {
            _instrumentDal.Create(instrument);
        }

        public List<Instrument> GetInstruments()
        {
            return _instrumentDal.GetInstrumentsWithType();
        }

        public List<Instrument> GetLimitedInstruments(int count)
        {
            return _instrumentDal.GetLimitedInstrumentsWithType(count);
        }
    }
}
