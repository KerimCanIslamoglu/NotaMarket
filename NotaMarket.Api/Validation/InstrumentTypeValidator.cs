using FluentValidation;
using NotaMarket.Api.Model.InstrumentType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotaMarket.Api.Validation
{
    public class InstrumentTypeValidator : AbstractValidator<CreateInstrumentTypeModel>
    {
        public InstrumentTypeValidator()
        {
            RuleFor(instrumentType => instrumentType.InstrumentTypeName).NotEmpty().WithMessage("Enstürman tipi adı alanı zorunludur.");
            RuleFor(instrumentType => instrumentType.PhotoUrl).NotEmpty().WithMessage("Enstürman tipi fotoğrafı adı alanı zorunludur.");
            RuleFor(instrumentType => instrumentType.CreatedOn).NotEmpty().WithMessage("Enstürman tipi oluşturulma tarihi alanı zorunludur.");
            RuleFor(instrumentType => instrumentType.Data).NotEmpty().WithMessage("Enstürman tipi fotoğrafı blob alanı zorunludur.");
            RuleFor(instrumentType => instrumentType.Description).NotEmpty().WithMessage("Enstürman tipi açıklama alanı zorunludur.");
            RuleFor(instrumentType => instrumentType.Extension).NotEmpty().WithMessage("Enstürman tipi uzantı alanı zorunludur.");
            RuleFor(instrumentType => instrumentType.FileName).NotEmpty().WithMessage("Enstürman tipi dosya adı alanı zorunludur.");
            RuleFor(instrumentType => instrumentType.FileType).NotEmpty().WithMessage("Enstürman tipi dosya tipi alanı zorunludur.");
            RuleFor(instrumentType => instrumentType.UploadedBy).NotEmpty().WithMessage("Enstürman tipi oluşturan kişi alanı zorunludur.");

        }
    }
}
