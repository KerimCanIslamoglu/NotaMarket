using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotaMarket.Api.Model;
using NotaMarket.Api.Model.InstrumentType;
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
        public IActionResult CreateInstrumentType(CreateInstrumentTypeModel createInstrumentTypeModel)
        {
            _instrumentTypeService.CreateInstrumentType(_mapper.Map<CreateInstrumentTypeModel, InstrumentType>(createInstrumentTypeModel));

            return Ok(new ResponseObjectModel<CreateInstrumentTypeModel>
            {
                Success = true,
                StatusCode = 200,
                Message = "Başarılı",
                Response = null
            });
        }

        [HttpPut]
        [Route("api/[controller]/UpdateInstrumentType")]
        public IActionResult UpdateInstrumentType(DeleteInstrumentTypeModel updateInstrumentTypeModel)
        {
            _instrumentTypeService.UpdateInstrumentType(_mapper.Map<DeleteInstrumentTypeModel, InstrumentType>(updateInstrumentTypeModel));

            return Ok(new ResponseObjectModel<DeleteInstrumentTypeModel>
            {
                Success = true,
                StatusCode = 200,
                Message = "Başarılı",
                Response = null
            });
        }

        [HttpPost]
        [Route("api/[controller]/DeleteInstrumentType")]
        public IActionResult DeleteInstrumentType(DeleteInstrumentTypeModel instrumentTypeModel)
        {
            _instrumentTypeService.DeleteInstrumentType(_mapper.Map<DeleteInstrumentTypeModel, InstrumentType>(instrumentTypeModel));

            return Ok(new ResponseObjectModel<DeleteInstrumentTypeModel>
            {
                Success = true,
                StatusCode = 200,
                Message = "Başarılı",
                Response = null
            });
        }
    }
}
