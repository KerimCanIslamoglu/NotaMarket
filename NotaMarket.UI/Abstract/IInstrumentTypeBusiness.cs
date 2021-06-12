using Microsoft.AspNetCore.Http;
using NotaMarket.UI.Models;
using NotaMarket.UI.Models.InstrumentTypeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotaMarket.UI.Abstract
{
    public interface IInstrumentTypeBusiness
    {
        Task<ResponseListModel<InstrumentTypeModel>> GetInstrumentTypesFromApi();
        Task<ResponseObjectModel<InstrumentTypeModel>> GetInstrumentTypeByIdFromApi(int id);
        Task<ResponseObjectModel<CreateInstrumentTypeModel>> CreateInstrumentTypeFromApi(CreateInstrumentTypeModel createInstrumentTypeModel);
        Task<ResponseObjectModel<InstrumentTypeModel>> UpdateInstrumentTypeFromApi(InstrumentTypeModel instrumentTypeModel);
        Task<ResponseObjectModel<InstrumentTypeModel>> DeleteInstrumentTypeFromApi(int id);
    }
}
