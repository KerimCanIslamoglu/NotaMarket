using FluentValidation;
using NotaMarket.Api.Model.Instrument;
using NotaMarket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotaMarket.Api.Validation
{
    public class InstrumentValidator : AbstractValidator<CreateInstrumentModel>
    {
        public InstrumentValidator()
        {
            RuleFor(instrument => instrument.InstrumentName).NotEmpty().WithMessage("Enstürman adı alanı zorunludur.");
            RuleFor(instrument => instrument.PhotoUrl).NotNull().WithMessage("Enstürman fotoğrafı boş bırakılamaz.");
            RuleFor(instrument => instrument.InstrumentTypeId).NotNull().WithMessage("Enstürman tipi Id boş bırakılamaz.");
            RuleFor(instrument => instrument.InstrumentTypeId).NotEqual(0).WithMessage("Geçerli bir enstürman tipi Id'si giriniz.");
            RuleFor(instrument => instrument.CreatedOn).NotEmpty().WithMessage("Enstürman oluşturulma tarihi alanı zorunludur.");
            RuleFor(instrument => instrument.Data).NotEmpty().WithMessage("Enstürman fotoğrafı blob alanı zorunludur.");
            RuleFor(instrument => instrument.Description).NotEmpty().WithMessage("Enstürman açıklama alanı zorunludur.");
            RuleFor(instrument => instrument.Extension).NotEmpty().WithMessage("Enstürman uzantı alanı zorunludur.");
            RuleFor(instrument => instrument.FileName).NotEmpty().WithMessage("Enstürman dosya adı alanı zorunludur.");
            RuleFor(instrument => instrument.FileType).NotEmpty().WithMessage("Enstürman dosya tipi alanı zorunludur.");
            RuleFor(instrument => instrument.UploadedBy).NotEmpty().WithMessage("Enstürman oluşturan kişi alanı zorunludur.");
        }   
    }
}
