using FluentValidation;
using NotaMarket.Api.Model;
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
            RuleFor(instrument => instrument.InstrumentTypeId).NotNull().WithMessage("Enstürman tipi Id boş bırakılamaz.");
            RuleFor(instrument => instrument.InstrumentTypeId).NotNull().WithMessage("Enstürman fotoğrafı boş bırakılamaz.");
            RuleFor(instrument => instrument.InstrumentTypeId).NotEqual(0).WithMessage("Geçerli bir enstürman tipi Id'si giriniz.");
        }   
    }
}
