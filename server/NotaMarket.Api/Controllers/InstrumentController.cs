using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotaMarket.Api.Model;
using NotaMarket.Api.Model.Instrument;
using NotaMarket.Business.Abstract;
using NotaMarket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotaMarket.Api.Controllers
{
    [ApiController]
    public class InstrumentController : ControllerBase
    {
        private IInstrumentService _instrumentService;
        private readonly IMapper _mapper;

        public InstrumentController(IInstrumentService instrumentService, IMapper mapper)
        {
            _instrumentService = instrumentService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("api/[controller]/GetInstruments")]
        public IActionResult GetInstruments()
        {
            var instruments = _instrumentService
                .GetInstruments()
                .Select(_mapper.Map<Instrument, InstrumentModel>)
                .ToList();



            return Ok(new ResponseListModel<InstrumentModel>
            {
                Success = true,
                StatusCode = 200,
                Message = "Başarılı",
                Response = instruments
            });

        }

        [HttpGet]
        [Route("api/[controller]/GetLimitedInstruments/{count}")]
        public IActionResult GetLimitedInstruments(int count)
        {
            var instruments = _instrumentService
                .GetLimitedInstruments(count)
                .Select(_mapper.Map<Instrument, InstrumentModel>)
                .ToList();



            return Ok(new ResponseListModel<InstrumentModel>
            {
                Success = true,
                StatusCode = 200,
                Message = "Başarılı",
                Response = instruments
            });

        }

        [HttpGet]
        [Route("api/[controller]/GetInstrumentById/{id}")]
        public IActionResult GetInstrumentById(int id)
        {
            var instrument= _instrumentService
                .GetInstrumentById(id);

            if (instrument == null)
            {
                return NotFound(new ResponseObjectModel<InstrumentModel>
                {
                    Success = false,
                    StatusCode = 404,
                    Message = $"{id} 'li enstürman bulunamadı",
                    Response = null
                });
            }

            return Ok(new ResponseObjectModel<InstrumentModel>
            {
                Success = true,
                StatusCode = 200,
                Message = "Başarılı",
                Response = _mapper.Map<Instrument, InstrumentModel>(instrument)
            });
        }

        [HttpPost]
        [Route("api/[controller]/CreateInstrument")]
        public IActionResult CreateInstrument(CreateInstrumentModel instrumentModel)
        {
            _instrumentService.CreateInstrument(_mapper.Map<CreateInstrumentModel, Instrument>(instrumentModel));

            return Ok(new ResponseObjectModel<CreateInstrumentModel>
            {
                Success = true,
                StatusCode = 200,
                Message = $"{instrumentModel.InstrumentName} isimli enstürman başarıyla oluşturuldu.",
                Response = null
            });
        }

        [HttpPut]
        [Route("api/[controller]/UpdateInstrument")]
        public IActionResult UpdateInstrument(UpdateInstrumentModel updateInstrumentModel)
        {
            _instrumentService.UpdateInstrument(_mapper.Map<UpdateInstrumentModel, Instrument>(updateInstrumentModel));

            return Ok(new ResponseObjectModel<UpdateInstrumentModel>
            {
                Success = true,
                StatusCode = 200,
                Message = $"{updateInstrumentModel.InstrumentName} isimli enstürman başarıyla güncelleştirildi.",
                Response = null
            });
        }

        [HttpDelete]
        [Route("api/[controller]/DeleteInstrument/{id}")]
        public IActionResult DeleteInstrumentType(int id)
        {
            var instrument = _instrumentService.GetInstrumentById(id);

            if (instrument == null)
            {
                return NotFound(new ResponseObjectModel<string>
                {
                    Success = false,
                    StatusCode = 404,
                    Message = $"{id} 'li enstürman bulunamadı",
                    Response = null
                });
            }
            _instrumentService.DeleteInstrument(instrument);

            return Ok(new ResponseObjectModel<string>
            {
                Success = true,
                StatusCode = 200,
                Message = $"{instrument.InstrumentName} isimli enstürman başarıyla silindi.",
                Response = null
            });
        }
    }
}
