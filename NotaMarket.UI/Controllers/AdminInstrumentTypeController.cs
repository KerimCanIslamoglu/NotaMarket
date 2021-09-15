using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotaMarket.UI.Abstract;
using NotaMarket.UI.Models;
using NotaMarket.UI.Models.Dtos;
using NotaMarket.UI.Models.Dtos.InstrumentTypeDtos;
using NotaMarket.UI.Models.InstrumentTypeModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
            //var model = new List<InstrumentTypeDto>();

            var instrumentType =await _instrumentTypeBusiness.GetInstrumentTypesFromApi();

            var model=instrumentType?.Response.Select(_mapper.Map<InstrumentTypeModel, InstrumentTypeDto>).ToList();

            if (model != null)
            {
                foreach (var item in model)
                {
                    if (item.Data.Length > 0)
                        item.Image = $"data:{item.FileType};base64,{Convert.ToBase64String(item.Data, 0, item.Data.Length)}";
                }
            }
            

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

            if (instrumentType.Success)
                TempData["SuccessMessage"] = instrumentType.Message;
            else
                TempData["ErrorMessage"] = instrumentType.Message;

            return RedirectToAction("Index");   //TODO ViewData ile geriye mesaj döndür.
        }

        [HttpGet]
        public async Task<IActionResult> UpdateInstrumentType(int id)
        {
            var instrumentType = await _instrumentTypeBusiness.GetInstrumentTypeByIdFromApi(id);

            if (instrumentType==null)
                return View("Index");  //TODO ViewData ile geriye mesaj döndür.

            var updateInstrumentTypeDto = new UpdateInstrumentTypeDto();

            using (var stream = new MemoryStream(instrumentType.Response?.Data))
            {
                IFormFile file = new FormFile(stream, 0, instrumentType.Response.Data.Length, instrumentType.Response.FileName, instrumentType.Response.FileName);

                updateInstrumentTypeDto.FormFile = file;
            }
            updateInstrumentTypeDto.Id = instrumentType.Response.Id;
            updateInstrumentTypeDto.InstrumentTypeName = instrumentType.Response.InstrumentTypeName;
           

            return View("Update", updateInstrumentTypeDto);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateInstrumentTypeUpload(UpdateInstrumentTypeDto updateInstrumentTypeDto)
        {
            var instrumentTypeModel = new InstrumentTypeModel();

            instrumentTypeModel.Id = updateInstrumentTypeDto.Id;
            instrumentTypeModel.InstrumentTypeName = updateInstrumentTypeDto.InstrumentTypeName;

            if (updateInstrumentTypeDto.FormFile!=null)
            {
                var fileName = Path.GetFileNameWithoutExtension(updateInstrumentTypeDto.FormFile?.FileName);
                var extension = Path.GetExtension(updateInstrumentTypeDto.FormFile?.FileName);

                instrumentTypeModel.FileType = updateInstrumentTypeDto.FormFile?.ContentType;
                instrumentTypeModel.Extension = extension;
                instrumentTypeModel.FileName = fileName;
                instrumentTypeModel.CreatedOn = DateTime.Now;
                instrumentTypeModel.UploadedBy = "Admin";
                instrumentTypeModel.Description = "Desc";
                instrumentTypeModel.PhotoUrl = "TestUrl";

                using (var dataStream = new MemoryStream())
                {
                    await updateInstrumentTypeDto.FormFile?.CopyToAsync(dataStream);
                    instrumentTypeModel.Data = dataStream.ToArray();
                }
            }
            else
            {
                var instrumentType = await _instrumentTypeBusiness.GetInstrumentTypeByIdFromApi(updateInstrumentTypeDto.Id);

                instrumentTypeModel.FileType = instrumentType.Response?.FileName;
                instrumentTypeModel.Extension = instrumentType.Response?.Extension;
                instrumentTypeModel.FileName = instrumentType.Response?.FileName;
                instrumentTypeModel.CreatedOn = instrumentType.Response?.CreatedOn;
                instrumentTypeModel.UploadedBy = instrumentType.Response?.UploadedBy;
                instrumentTypeModel.Description = instrumentType.Response?.Description;
                instrumentTypeModel.PhotoUrl = instrumentType.Response?.PhotoUrl;
                instrumentTypeModel.Data = instrumentType.Response?.Data;

            }

            var instrumentTypeResult=await _instrumentTypeBusiness.UpdateInstrumentTypeFromApi(instrumentTypeModel);

            if (instrumentTypeResult.Success)
                TempData["SuccessMessage"] = instrumentTypeResult.Message;
            else
                TempData["ErrorMessage"] = instrumentTypeResult.Message;

            return RedirectToAction("Index");   //TODO ViewData ile geriye mesaj döndür.
        }


        [HttpGet]
        public async Task<IActionResult> DeleteInstrumentType(int id)
        {
            var instrumentTypeResult = await _instrumentTypeBusiness.DeleteInstrumentTypeFromApi(id);

            if (instrumentTypeResult.Success)
                TempData["SuccessMessage"] = instrumentTypeResult.Message;
            else
                TempData["ErrorMessage"] = instrumentTypeResult.Message;

            return RedirectToAction("Index");  //TODO ViewData ile geriye mesaj döndür.
        }
    }
}
