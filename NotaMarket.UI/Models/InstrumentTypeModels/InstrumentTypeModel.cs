using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotaMarket.UI.Models.InstrumentTypeModels
{
    public class InstrumentTypeModel
    {
        public int Id { get; set; }
        public string InstrumentTypeName { get; set; }
        public string PhotoUrl { get; set; }
        public byte[] Data { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string Extension { get; set; }
        public string Description { get; set; }
        public string UploadedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
