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
    public class InstrumentTypeManager : IInstrumentTypeService
    {
        private IInstrumentTypeDal _instrumentTypeDal;

        public InstrumentTypeManager(IInstrumentTypeDal instrumentTypeDal)
        {
            _instrumentTypeDal = instrumentTypeDal;
        }

        public void CreateInstrumentType(InstrumentType instrumentType)
        {
            _instrumentTypeDal.Create(instrumentType);
        }

        public List<InstrumentType> GetInstrumentTypes()
        {
            return _instrumentTypeDal.GetInstrumentTypesWithInstrument();
        }
    }
}
