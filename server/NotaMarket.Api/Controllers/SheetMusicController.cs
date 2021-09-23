using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotaMarket.Api.Model;
using NotaMarket.Api.Model.SheetMusic;
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
        [Authorize(Roles = "Admin,Musician")]
        [Route("api/[controller]/CreateSheetMusic")]
        public IActionResult CreateSheetMusic(CreateSheetMusicModel createSheetMusicModel)
        {
            _sheetMusicService.CreateSheetMusic(_mapper.Map<CreateSheetMusicModel, SheetMusic>(createSheetMusicModel));

            return Ok(new ResponseObjectModel<CreateSheetMusicModel>
            {
                Success = true,
                StatusCode = 200,
                Message = $"{createSheetMusicModel.SheetMusicName} isimli nota başarıyla oluşturuldu.",
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

        [HttpGet]
        [Route("api/[controller]/GetLimitedSheetMusics/{count}")]
        public IActionResult GetLimitedSheetMusics(int count)
        {
            var sheetMusics = _sheetMusicService
                .GetLimitedSheetMusics(count)
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
