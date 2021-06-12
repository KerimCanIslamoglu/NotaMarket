using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using NotaMarket.UI.Abstract;
using NotaMarket.UI.ApiHelper;
using NotaMarket.UI.Models;
using NotaMarket.UI.Models.InstrumentTypeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotaMarket.UI.Concrete
{
    public class InstrumentTypeBusiness : IInstrumentTypeBusiness
    {
        private IRestApiGenerator _restApiGenerator;
        private readonly IConfiguration _config;

        public InstrumentTypeBusiness(IRestApiGenerator restApiGenerator, IConfiguration config)
        {
            _restApiGenerator = restApiGenerator;
            _config = config;
        }

        public async Task<ResponseListModel<InstrumentTypeModel>> GetInstrumentTypesFromApi()
        {
            string url = _config.GetValue<string>("ApiUrl") + "InstrumentType/GetInstrumentTypes";
            var instrumentsTypes = await _restApiGenerator.GetApi<ResponseListModel<InstrumentTypeModel>>(url);

            return instrumentsTypes;
        }

        public async Task<ResponseObjectModel<CreateInstrumentTypeModel>> CreateInstrumentTypeFromApi(CreateInstrumentTypeModel createInstrumentTypeModel)
        {
            string url = _config.GetValue<string>("ApiUrl") + "InstrumentType/CreateInstrumentType";
            var instrumentsTypes = await _restApiGenerator.PostApi<ResponseObjectModel<CreateInstrumentTypeModel>>(createInstrumentTypeModel,url);

            return instrumentsTypes;
        }

        public async Task<ResponseObjectModel<InstrumentTypeModel>> UpdateInstrumentTypeFromApi(InstrumentTypeModel instrumentTypeModel)
        {
            string url = _config.GetValue<string>("ApiUrl") + "InstrumentType/UpdateInstrumentType";
            var instrumentsTypes = await _restApiGenerator.PutApi<ResponseObjectModel<InstrumentTypeModel>>(instrumentTypeModel, url);

            return instrumentsTypes;
        }

        public async Task<ResponseObjectModel<InstrumentTypeModel>> DeleteInstrumentTypeFromApi(int id)
        {
            string url = _config.GetValue<string>("ApiUrl") + "InstrumentType/DeleteInstrumentType/"+id;
            var instrumentsTypes = await _restApiGenerator.DeleteApi<ResponseObjectModel<InstrumentTypeModel>>(url);

            return instrumentsTypes;
        }

        public async Task<ResponseObjectModel<InstrumentTypeModel>> GetInstrumentTypeByIdFromApi(int id)
        {
            string url = _config.GetValue<string>("ApiUrl") + "InstrumentType/GetInstrumentTypeById/" + id;
            var instrumentsType = await _restApiGenerator.GetApi<ResponseObjectModel<InstrumentTypeModel>>(url);

            return instrumentsType;
        }
    }
}
