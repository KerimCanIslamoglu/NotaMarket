using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotaMarket.UI.Abstract;
using NotaMarket.UI.Models.Dtos.InstrumentDtos;
using NotaMarket.UI.Models.Dtos.InstrumentTypeDtos;
using NotaMarket.UI.Models.InstrumentModels;
using NotaMarket.UI.Models.InstrumentTypeModels;
using System;
using System.Collections.Generic;
using System.IO;
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
            model.InstrumentTypes.AddRange(_mapper.Map<List<InstrumentTypeModel>, List<InstrumentTypeDto>>(insturmentTypes?.Response.ToList()));

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUpload(CreateInstrumentDto createInstrumentDto)
        {
            var fileName = Path.GetFileNameWithoutExtension(createInstrumentDto.FormFile.FileName);
            var extension = Path.GetExtension(createInstrumentDto.FormFile.FileName);

            var createInstrumentModel = new CreateInstrumentModel();

            createInstrumentModel.FileType = createInstrumentDto.FormFile.ContentType;
            createInstrumentModel.Extension = extension;
            createInstrumentModel.FileName = fileName;
            createInstrumentModel.CreatedOn = DateTime.Now;
            createInstrumentModel.UploadedBy = "Admin";
            createInstrumentModel.Description = "Desc";
            createInstrumentModel.PhotoUrl = "TestUrl";
            createInstrumentModel.InstrumentName = createInstrumentDto.InstrumentName;
            createInstrumentModel.InstrumentTypeId = createInstrumentDto.InstrumentTypeId;

            using (var dataStream = new MemoryStream())
            {
                await createInstrumentDto.FormFile.CopyToAsync(dataStream);
                createInstrumentModel.Data = dataStream.ToArray();
            }

            var instrument = await _instrumentBusiness.CreateInstrumentFromApi(createInstrumentModel);

            if (instrument.Success)
            {
                TempData["SuccessMessage"] = instrument.Message;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessage"] = instrument.Message;
                return RedirectToAction("Create", createInstrumentDto);
            }

        }


        [HttpGet]
        public async Task<IActionResult> UpdateInstrument(int id)
        {
            var instrument = await _instrumentBusiness.GetInstrumentByIdFromApi(id);

            if (instrument == null)
            {
                TempData["ErrorMessage"] = instrument.Message;
                return View("Index");  
            }

            var updateInstrumentDto = new UpdateInstrumentDto();

            using (var stream = new MemoryStream(instrument.Response?.Data))
            {
                IFormFile file = new FormFile(stream, 0, instrument.Response.Data.Length, instrument.Response.FileName, instrument.Response.FileName);

                updateInstrumentDto.FormFile = file;
            }
            updateInstrumentDto.Id = instrument.Response.Id;
            updateInstrumentDto.InstrumentName = instrument.Response.InstrumentName;
            updateInstrumentDto.InstrumentTypeId = instrument.Response.InstrumentTypeId;
            updateInstrumentDto.InstrumentTypes = new List<InstrumentTypeDto>();

            var insturmentTypes = await _instrumentTypeBusiness.GetInstrumentTypesFromApi();
            updateInstrumentDto.InstrumentTypes.AddRange(_mapper.Map<List<InstrumentTypeModel>, List<InstrumentTypeDto>>(insturmentTypes?.Response.ToList()));


            return View("Update", updateInstrumentDto);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateInstrumentUpload(UpdateInstrumentDto updateInstrumentDto)
        {
            var instrumentModel = new InstrumentModel();

            instrumentModel.Id = updateInstrumentDto.Id;
            instrumentModel.InstrumentTypeId = updateInstrumentDto.InstrumentTypeId;
            instrumentModel.InstrumentName = updateInstrumentDto.InstrumentName;

            if (updateInstrumentDto.FormFile != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(updateInstrumentDto.FormFile?.FileName);
                var extension = Path.GetExtension(updateInstrumentDto.FormFile?.FileName);

                instrumentModel.FileType = updateInstrumentDto.FormFile?.ContentType;
                instrumentModel.Extension = extension;
                instrumentModel.FileName = fileName;
                instrumentModel.CreatedOn = DateTime.Now;
                instrumentModel.UploadedBy = "Admin";
                instrumentModel.Description = "Desc";
                instrumentModel.PhotoUrl = "TestUrl";

                using (var dataStream = new MemoryStream())
                {
                    await updateInstrumentDto.FormFile?.CopyToAsync(dataStream);
                    instrumentModel.Data = dataStream.ToArray();
                }
            }
            else
            {
                var instrument = await _instrumentBusiness.GetInstrumentByIdFromApi(updateInstrumentDto.Id);

                instrumentModel.FileType = instrument.Response?.FileName;
                instrumentModel.Extension = instrument.Response?.Extension;
                instrumentModel.FileName = instrument.Response?.FileName;
                instrumentModel.CreatedOn = instrument.Response?.CreatedOn;
                instrumentModel.UploadedBy = instrument.Response?.UploadedBy;
                instrumentModel.Description = instrument.Response?.Description;
                instrumentModel.PhotoUrl = instrument.Response?.PhotoUrl;
                instrumentModel.Data = instrument.Response?.Data;

            }

            var instrumentResult = await _instrumentBusiness.UpdateInstrumentFromApi(instrumentModel);

            if (instrumentResult.Success)
            {
                TempData["SuccessMessage"] = instrumentResult.Message;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessage"] = instrumentResult.Message;
                return RedirectToAction("UpdateInstrument", updateInstrumentDto);
            }
        }


        [HttpGet]
        public async Task<IActionResult> DeleteInstrument(int id)
        {
            var instrumentResult = await _instrumentBusiness.DeleteInstrumentFromApi(id);

            if (instrumentResult.Success)
                TempData["SuccessMessage"] = instrumentResult.Message;
            else
                TempData["ErrorMessage"] = instrumentResult.Message;

            return RedirectToAction("Index");  
        }
    }
}
