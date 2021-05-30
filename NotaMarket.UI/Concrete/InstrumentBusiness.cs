using Microsoft.Extensions.Configuration;
using NotaMarket.UI.Abstract;
using NotaMarket.UI.ApiHelper;
using NotaMarket.UI.Models;
using NotaMarket.UI.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotaMarket.UI.Concrete
{
    public class InstrumentBusiness : IInstrumentBusiness
    {
        private IRestApiGenerator<ResponseListModel<List<InstrumentModel>>> _restApiGenerator;
        private readonly IConfiguration _config;

        public InstrumentBusiness(IRestApiGenerator<ResponseListModel<List<InstrumentModel>>> restApiGenerator, IConfiguration config)
        {
            _restApiGenerator = restApiGenerator;
            _config = config;
        }

        public async Task<ResponseListModel<List<InstrumentModel>>> GetInstrumentsFromApi()
        {
            string url = _config.GetValue<string>("ApiUrl")+ "Instrument/GetInstruments";
            var instrumentList = new ResponseListModel<List<InstrumentModel>>();
            var instruments = await _restApiGenerator.GetApi(instrumentList, url);

            return instruments;
        }
    }
}
