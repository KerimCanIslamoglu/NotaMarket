using Microsoft.Extensions.Configuration;
using NotaMarket.UI.Abstract;
using NotaMarket.UI.ApiHelper;
using NotaMarket.UI.Models;
using NotaMarket.UI.Models.InstrumentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotaMarket.UI.Concrete
{
    public class InstrumentBusiness : IInstrumentBusiness
    {
        private IRestApiGenerator _restApiGenerator;
        private readonly IConfiguration _config;

        public InstrumentBusiness(IRestApiGenerator restApiGenerator, IConfiguration config)
        {
            _restApiGenerator = restApiGenerator;
            _config = config;
        }

        public async Task<ResponseListModel<InstrumentModel>> GetInstrumentsFromApi()
        {
            string url = _config.GetValue<string>("ApiUrl")+ "Instrument/GetInstruments";
            var instruments = await _restApiGenerator.GetApi<ResponseListModel<InstrumentModel>>(url);

            return instruments;
        }

        public async Task<ResponseListModel<InstrumentModel>> GetHomePageInstrumentsFromApi(int count)
        {
            string url = _config.GetValue<string>("ApiUrl") + "Instrument/GetLimitedInstruments/"+count;
            var instruments = await _restApiGenerator.GetApi<ResponseListModel<InstrumentModel>>(url);

            return instruments;
        }

        public async Task<ResponseObjectModel<InstrumentModel>> GetInstrumentByIdFromApi(int id)
        {
            string url = _config.GetValue<string>("ApiUrl") + "Instrument/GetInstrumentById/" + id;
            var instrument = await _restApiGenerator.GetApi<ResponseObjectModel<InstrumentModel>>(url);

            return instrument;
        }

        public async Task<ResponseObjectModel<CreateInstrumentModel>> CreateInstrumentFromApi(CreateInstrumentModel createInstrumentModel)
        {
            string url = _config.GetValue<string>("ApiUrl") + "Instrument/CreateInstrument";
            var instrument = await _restApiGenerator.PostApi<ResponseObjectModel<CreateInstrumentModel>>(createInstrumentModel, url);

            return instrument;
        }

        public async Task<ResponseObjectModel<InstrumentModel>> UpdateInstrumentFromApi(InstrumentModel instrumentModel)
        {
            string url = _config.GetValue<string>("ApiUrl") + "Instrument/UpdateInstrument";
            var instrument = await _restApiGenerator.PutApi<ResponseObjectModel<InstrumentModel>>(instrumentModel, url);

            return instrument;
        }

        public async Task<ResponseObjectModel<InstrumentModel>> DeleteInstrumentFromApi(int id)
        {
            string url = _config.GetValue<string>("ApiUrl") + "Instrument/DeleteInstrument/" + id;
            var instrument = await _restApiGenerator.DeleteApi<ResponseObjectModel<InstrumentModel>>(url);

            return instrument;
        }
    }
}
