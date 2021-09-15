using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        [Route("api/[controller]/GetInstrumentTypeById/{id}")]
        public IActionResult GetInstrumentTypeById(int id)
        {
            var instrumentTypes = _instrumentTypeService
                .GetInstrumentTypeById(id);

            if (instrumentTypes == null)
            {
                return NotFound(new ResponseObjectModel<InstrumentTypeModel>
                {
                    Success = false,
                    StatusCode = 404,
                    Message = $"{id} 'li enstürman tipi bulunamadı",
                    Response = null
                });
            }

            return Ok(new ResponseObjectModel<InstrumentTypeModel>
            {
                Success = true,
                StatusCode = 200,
                Message = "Başarılı",
                Response = _mapper.Map<InstrumentType,InstrumentTypeModel>(instrumentTypes) 
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
                Message = $"{createInstrumentTypeModel.InstrumentTypeName} isimli enstürman tipi başarıyla oluşturuldu.",
                Response = null
            });
        }

        [HttpPut]
        [Route("api/[controller]/UpdateInstrumentType")]
        public IActionResult UpdateInstrumentType(UpdateInstrumentTypeModel updateInstrumentTypeModel)
        {
            _instrumentTypeService.UpdateInstrumentType(_mapper.Map<UpdateInstrumentTypeModel, InstrumentType>(updateInstrumentTypeModel));

            return Ok(new ResponseObjectModel<UpdateInstrumentTypeModel>
            {
                Success = true,
                StatusCode = 200,
                Message = $"{updateInstrumentTypeModel.InstrumentTypeName} isimli enstürman tipi başarıyla güncelleştirildi.",
                Response = null
            });
        }

        [HttpDelete]
        [Route("api/[controller]/DeleteInstrumentType/{id}")]
        public IActionResult DeleteInstrumentType(int id)
        {
            var instrumentType = _instrumentTypeService.GetInstrumentTypeById(id);

            if (instrumentType==null)
            {
                return NotFound(new ResponseObjectModel<string>
                {
                    Success = false,
                    StatusCode = 404,
                    Message = $"{id} 'li enstürman tipi bulunamadı",
                    Response = null
                });
            }
            _instrumentTypeService.DeleteInstrumentType(instrumentType);

            return Ok(new ResponseObjectModel<string>
            {
                Success = true,
                StatusCode = 200,
                Message = $"{instrumentType.InstrumentTypeName} isimli enstürman tipi başarıyla silindi.",
                Response = null
            });
        }
    }
}
