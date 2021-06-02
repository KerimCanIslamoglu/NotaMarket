using Microsoft.Extensions.Configuration;
using NotaMarket.UI.Abstract;
using NotaMarket.UI.ApiHelper;
using NotaMarket.UI.Models;
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
            var instruments = await _restApiGenerator.GetApi<ResponseListModel<InstrumentTypeModel>>(url);

            return instruments;
        }
    }
}
