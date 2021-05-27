using FluentValidation;
using NotaMarket.Api.Model;
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

        }
    }
}
