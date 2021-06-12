using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotaMarket.Api.Model;
using NotaMarket.Api.Model.Composer;
using NotaMarket.Business.Abstract;
using NotaMarket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotaMarket.Api.Controllers
{
    [ApiController]
    public class ComposerController : ControllerBase
    {
        private IComposerService _composerService;
        private readonly IMapper _mapper;

        public ComposerController(IComposerService composerService, IMapper mapper)
        {
            _composerService = composerService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("api/[controller]/CreateComposer")]
        public IActionResult CreateComposer(ComposerModel composerModel)
        {
            _composerService.CreateComposer(_mapper.Map<ComposerModel, Composer>(composerModel));

            return Ok(new ResponseObjectModel<ComposerModel>
            {
                Success = true,
                StatusCode = 200,
                Message = "Başarılı",
                Response = null
            });
        }

        [HttpGet]
        [Route("api/[controller]/GetComposers")]
        public IActionResult GetComposers()
        {
            var composers = _composerService
                .GetComposers()
                .Select(_mapper.Map<Composer, ComposerModel>)
                .ToList();

            return Ok(new ResponseListModel<ComposerModel>
            {
                Success = true,
                StatusCode=200,
                Message = "Başarılı",
                Response = composers
            });
        }

        [HttpGet]
        [Route("api/[controller]/GetComposerDetail/{id}")]
        public IActionResult GetComposerDetail(int id)
        {
            var composer = _composerService
                .GetComposerById(id);

            var mappedComposer = _mapper.Map<Composer, ComposerModel>(composer);

            return Ok(new ResponseObjectModel<ComposerModel>
            {
                Success = true,
                StatusCode = 200,
                Message = "Başarılı",
                Response = mappedComposer
            });
        }
    }
}
