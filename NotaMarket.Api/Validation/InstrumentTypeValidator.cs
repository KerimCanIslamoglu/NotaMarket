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

        }
    }
}
