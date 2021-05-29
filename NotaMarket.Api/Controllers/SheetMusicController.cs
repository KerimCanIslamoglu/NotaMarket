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
    public class SheetMusicController : ControllerBase
    {
        private ISheetMusicService _sheetMusicService;
        private readonly IMapper _mapper;

        public SheetMusicController(ISheetMusicService sheetMusicService, IMapper mapper)
        {
            _sheetMusicService = sheetMusicService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("api/[controller]/CreateSheetMusic")]
        public IActionResult CreateSheetMusic(CreateSheetMusicModel createSheetMusicModel)
        {
            _sheetMusicService.CreateSheetMusic(_mapper.Map<CreateSheetMusicModel, SheetMusic>(createSheetMusicModel));

            return Ok(new ResponseObjectModel<CreateSheetMusicModel>
            {
                Success = true,
                StatusCode = 200,
                Message = "Başarılı",
                Response = null
            });
        }

        [HttpGet]
        [Route("api/[controller]/GetSheetMusic")]
        public IActionResult GetSheetMusic()
        {
            var sheetMusics = _sheetMusicService
                .GetSheetMusics()
                .Select(_mapper.Map<SheetMusic, SheetMusicModel>)
                .ToList();

            return Ok(new ResponseListModel<SheetMusicModel>
            {
                Success = true,
                StatusCode = 200,
                Message = "Başarılı",
                Response = sheetMusics
            });

        }
    }
}
