using NotaMarket.UI.Models;
using NotaMarket.UI.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotaMarket.UI.Abstract
{
    public interface IInstrumentBusiness
    {
        Task<ResponseListModel<InstrumentModel>> GetInstrumentsFromApi();
        Task<ResponseListModel<InstrumentModel>> GetHomePageInstrumentsFromApi(int count);
    }
}
