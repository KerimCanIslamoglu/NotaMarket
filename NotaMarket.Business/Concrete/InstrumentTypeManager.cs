using Microsoft.AspNetCore.Http;
using NotaMarket.Business.Abstract;
using NotaMarket.DataAccess.Abstract;
using NotaMarket.Entities;
using System;
using System.Collections.Generic;
using System.IO;
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

        public void DeleteInstrumentType(InstrumentType instrumentType)
        {
            _instrumentTypeDal.Delete(instrumentType);
        }

        public InstrumentType GetInstrumentTypeById(int id)
        {
            return _instrumentTypeDal.GetById(id);
        }

        public List<InstrumentType> GetInstrumentTypes()
        {
            return _instrumentTypeDal.GetInstrumentTypesWithInstrument();
        }

        public void UpdateInstrumentType(InstrumentType instrumentType)
        {
            _instrumentTypeDal.Update(instrumentType);
        }
    }
}
