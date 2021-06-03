using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotaMarket.UI.Abstract;
using NotaMarket.UI.Models;
using NotaMarket.UI.Models.Dtos;
using System;
using System.Collections.Generic;
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
        public async Task<IActionResult> CreateUpload(CreateInstrumentTypeModel createInstrumentTypeModel)
        {
            createInstrumentTypeModel.CreatedOn = DateTime.Now;
            createInstrumentTypeModel.UploadedBy = "Admin";
            createInstrumentTypeModel.Description = "Desc";
          
            var instrumentType = await _instrumentTypeBusiness.CreateInstrumentTypeFromApi(createInstrumentTypeModel);

            return RedirectToAction("Index");
        }
    }
}
