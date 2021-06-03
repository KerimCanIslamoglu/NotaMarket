using Microsoft.AspNetCore.Http;
using NotaMarket.Business.Abstract;
using NotaMarket.DataAccess.Abstract;
using NotaMarket.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaMarket.Business.Concrete
{
    public class InstrumentTypeManager : IInstrumentTypeService
    {
        private IInstrumentTypeDal _instrumentTypeDal;

        public InstrumentTypeManager(IInstrumentTypeDal instrumentTypeDal)
        {
            _instrumentTypeDal = instrumentTypeDal;
        }

        public async void CreateInstrumentType(IFormFile file, InstrumentType instrumentType)
        {
            if (file!=null)
            {
                var basePath = Path.Combine(Directory.GetCurrentDirectory() + "\\Files\\InstrumentTypes\\");
                bool basePathExists = System.IO.Directory.Exists(basePath);
                if (!basePathExists) Directory.CreateDirectory(basePath);
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var filePath = Path.Combine(basePath, file.FileName);
                var extension = Path.GetExtension(file.FileName);
                if (!System.IO.File.Exists(filePath))
                {
                    //File system
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    //Db upload
                    using (var dataStream = new MemoryStream())
                    {
                        await file.CopyToAsync(dataStream);
                        instrumentType.Data = dataStream.ToArray();
                    }

                    instrumentType.FileType = file.ContentType;
                    instrumentType.Extension = extension;
                    instrumentType.FileName = fileName;
                    instrumentType.PhotoUrl = filePath;

                    _instrumentTypeDal.Create(instrumentType);
                }
            }
        }

        public List<InstrumentType> GetInstrumentTypes()
        {
            return _instrumentTypeDal.GetInstrumentTypesWithInstrument();
        }
    }
}
