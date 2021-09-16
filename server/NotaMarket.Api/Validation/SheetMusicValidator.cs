using FluentValidation;
using NotaMarket.Api.Model.SheetMusic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotaMarket.Api.Validation
{
    public class SheetMusicValidator : AbstractValidator<CreateSheetMusicModel>
    {
        public SheetMusicValidator()
        {
            RuleFor(sheetMusic => sheetMusic.Description).NotEmpty().WithMessage("Açıklama alanı zorunludur.");
            RuleFor(sheetMusic => sheetMusic.SheetMusicName).NotEmpty().WithMessage("Nota ismi alanı zorunludur.");
            RuleFor(sheetMusic => sheetMusic.SheetUrl).NotEmpty().WithMessage("Nota url alanı zorunludur.");
            RuleFor(sheetMusic => sheetMusic.ComposerId).NotEmpty().WithMessage("Besteci id alanı zorunludur.");
            RuleFor(sheetMusic => sheetMusic.InstrumentId).NotEmpty().WithMessage("Enstürman id alanı zorunludur.");
            RuleFor(sheetMusic => sheetMusic.CreatedAt).NotEmpty().WithMessage("Oluşturulma tarihi alanı zorunludur.");
            RuleFor(sheetMusic => sheetMusic.CreatedBy).NotEmpty().WithMessage("Oluşturan kişi alanı zorunludur.");
        }
    }
}
