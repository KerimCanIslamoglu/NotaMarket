using NotaMarket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaMarket.DataAccess.Abstract
{
    public interface IInstrumentDal : IRepositoryBase<Instrument>
    {
        List<Instrument> GetInstrumentsWithType();
        List<Instrument> GetLimitedInstrumentsWithType(int count);
    }
}
