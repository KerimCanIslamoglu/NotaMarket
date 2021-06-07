using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotaMarket.UI.Abstract;
using NotaMarket.UI.Models;
using NotaMarket.UI.Models.Dtos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NotaMarket.UI.Controllers
{
    public class AdminInstrumentTypeController : Controller
    {
        private IInstrumentTypeBusiness _instrumentTypeBusiness;
        private readonly IMapper _mapper;


        public AdminInstrumentTypeController(IInstrumentTypeBusiness instrumentTypeBusiness, IMapper mapper)
        {
            _instrumentTypeBusiness = instrumentTypeBusiness;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var model = new List<InstrumentTypeDto>();

            var instrumentType =await _instrumentTypeBusiness.GetInstrumentTypesFromApi();

            model=instrumentType?.Response.Select(_mapper.Map<InstrumentTypeModel, InstrumentTypeDto>).ToList();

            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUpload(CreateInstrumentTypeDto createInstrumentTypeDto)
        {
            var fileName = Path.GetFileNameWithoutExtension(createInstrumentTypeDto.FormFile.FileName);
            var extension = Path.GetExtension(createInstrumentTypeDto.FormFile.FileName);

            var createInstrumentTypeModel = new CreateInstrumentTypeModel();

            createInstrumentTypeModel.FileType = createInstrumentTypeDto.FormFile.ContentType;
            createInstrumentTypeModel.Extension = extension;
            createInstrumentTypeModel.FileName = fileName;
            createInstrumentTypeModel.CreatedOn = DateTime.Now;
            createInstrumentTypeModel.UploadedBy = "Admin";
            createInstrumentTypeModel.Description = "Desc";
            createInstrumentTypeModel.PhotoUrl = "TestUrl";
            createInstrumentTypeModel.InstrumentTypeName = createInstrumentTypeDto.InstrumentTypeName;

            using (var dataStream = new MemoryStream())
            {
                await createInstrumentTypeDto.FormFile.CopyToAsync(dataStream);
                createInstrumentTypeModel.Data = dataStream.ToArray();
            }

            var instrumentType = await _instrumentTypeBusiness.CreateInstrumentTypeFromApi(createInstrumentTypeModel);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteInstrumentType(InstrumentTypeDto instrumentTypeDto)
        {

            var instrumentType = await _instrumentTypeBusiness
                .DeleteInstrumentTypeFromApi(_mapper.Map<InstrumentTypeDto, CreateInstrumentTypeModel>(instrumentTypeDto));

            return RedirectToAction("Index");
        }
    }
}
