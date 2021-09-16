using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaMarket.Entities
{
    public class InstrumentType
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

        public ICollection<Instrument> Instruments { get; set; }
    }
}
