using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NotaMarket.UI.Abstract;
using NotaMarket.UI.Models.Dtos.InstrumentDtos;
using NotaMarket.UI.Models.Dtos.InstrumentTypeDtos;
using NotaMarket.UI.Models.InstrumentModels;
using NotaMarket.UI.Models.InstrumentTypeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotaMarket.UI.Controllers
{
    public class AdminInstrumentController : Controller
    {
        private IInstrumentBusiness _instrumentBusiness;
        private IInstrumentTypeBusiness _instrumentTypeBusiness;
        private readonly IMapper _mapper;

        public AdminInstrumentController(IInstrumentBusiness instrumentBusiness, IInstrumentTypeBusiness instrumentTypeBusiness, IMapper mapper)
        {
            _instrumentBusiness = instrumentBusiness;
            _instrumentTypeBusiness = instrumentTypeBusiness;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new List<InstrumentDto>();

            var instrument = await _instrumentBusiness.GetInstrumentsFromApi();

            model = instrument?.Response.Select(_mapper.Map<InstrumentModel, InstrumentDto>).ToList();

            foreach (var item in model)
            {
                if (item.Data.Length > 0)
                    item.Image = $"data:{item.FileType};base64,{Convert.ToBase64String(item.Data, 0, item.Data.Length)}";
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var insturmentTypes = await _instrumentTypeBusiness.GetInstrumentTypesFromApi();

            var model = new CreateInstrumentDto();
            model.InstrumentTypes = new List<InstrumentTypeDto>();
            model.InstrumentTypes.AddRange(_mapper.Map<List<InstrumentTypeModel>, List<InstrumentTypeDto>>(insturmentTypes.Response.ToList()));

            return View(model);
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateUpload(CreateInstrumentTeDto createInstrumentTypeDto)
        //{
        //    var fileName = Path.GetFileNameWithoutExtension(createInstrumentTypeDto.FormFile.FileName);
        //    var extension = Path.GetExtension(createInstrumentTypeDto.FormFile.FileName);

        //    var createInstrumentTypeModel = new CreateInstrumentTypeModel();

        //    createInstrumentTypeModel.FileType = createInstrumentTypeDto.FormFile.ContentType;
        //    createInstrumentTypeModel.Extension = extension;
        //    createInstrumentTypeModel.FileName = fileName;
        //    createInstrumentTypeModel.CreatedOn = DateTime.Now;
        //    createInstrumentTypeModel.UploadedBy = "Admin";
        //    createInstrumentTypeModel.Description = "Desc";
        //    createInstrumentTypeModel.PhotoUrl = "TestUrl";
        //    createInstrumentTypeModel.InstrumentTypeName = createInstrumentTypeDto.InstrumentTypeName;

        //    using (var dataStream = new MemoryStream())
        //    {
        //        await createInstrumentTypeDto.FormFile.CopyToAsync(dataStream);
        //        createInstrumentTypeModel.Data = dataStream.ToArray();
        //    }

        //    var instrumentType = await _instrumentTypeBusiness.CreateInstrumentTypeFromApi(createInstrumentTypeModel);

        //    if (instrumentType.Success)
        //        TempData["SuccessMessage"] = instrumentType.Message;
        //    else
        //        TempData["ErrorMessage"] = instrumentType.Message;

        //    return RedirectToAction("Index");   //TODO ViewData ile geriye mesaj döndür.
        //}
    }
}
