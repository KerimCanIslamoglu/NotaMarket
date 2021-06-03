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
    public class InstrumentTypeController : ControllerBase
    {
        private IInstrumentTypeService _instrumentTypeService;
        private readonly IMapper _mapper;

        public InstrumentTypeController(IInstrumentTypeService instrumentTypeService, IMapper mapper)
        {
            _instrumentTypeService = instrumentTypeService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("api/[controller]/GetInstrumentTypes")]
        public IActionResult GetInstrumentTypes()
        {
            var instrumentTypes = _instrumentTypeService
                .GetInstrumentTypes()
                .Select(_mapper.Map<InstrumentType, InstrumentTypeModel>)
                .ToList();

            return Ok(new ResponseListModel<InstrumentTypeModel>
            {
                Success = true,
                StatusCode = 200,
                Message = "Başarılı",
                Response = instrumentTypes
            });
        }

        [HttpPost]
        [Route("api/[controller]/CreateInstrumentType")]
        public IActionResult CreateInstrumentType([FromForm] CreateInstrumentTypeModel CreateInstrumentTypeModel)
        {
            _instrumentTypeService.CreateInstrumentType(CreateInstrumentTypeModel.FormFile,_mapper.Map<CreateInstrumentTypeModel, InstrumentType>(CreateInstrumentTypeModel));

            return Ok(new ResponseObjectModel<CreateInstrumentTypeModel>
            {
                Success = true,
                StatusCode = 200,
                Message = "Başarılı",
                Response = null
            });
        }
    }
}
