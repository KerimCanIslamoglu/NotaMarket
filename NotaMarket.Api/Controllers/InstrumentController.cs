using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotaMarket.Api.Model;
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

        [HttpPost]
        [Route("api/[controller]/CreateInstrument")]
        public IActionResult CreateInstrument(CreateInstrumentModel instrumentModel)
        {
            _instrumentService.CreateInstrument(_mapper.Map<CreateInstrumentModel, Instrument>(instrumentModel));

            return Ok(new ResponseObjectModel<CreateInstrumentModel>
            {
                Success = true,
                StatusCode = 200,
                Message = "Başarılı",
                Response = null
            });
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
    }
}
