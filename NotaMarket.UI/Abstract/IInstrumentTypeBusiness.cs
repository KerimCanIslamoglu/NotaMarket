using NotaMarket.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotaMarket.UI.Abstract
{
    public interface IInstrumentTypeBusiness
    {
        Task<ResponseListModel<InstrumentTypeModel>> GetInstrumentTypesFromApi();
    }
}
