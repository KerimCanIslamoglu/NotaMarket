using FluentValidation;
using NotaMarket.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotaMarket.Api.Validation
{
    public class ComposerValidator : AbstractValidator<ComposerModel>
    {
        public ComposerValidator()
        {
            RuleFor(composer => composer.Biography).NotEmpty().WithMessage("Biyografi alanı zorunludur.");
            RuleFor(composer => composer.ComposerName).NotEmpty().WithMessage("Besteci ismi alanı zorunludur.");
            RuleFor(composer => composer.CreatedAt).NotEmpty().WithMessage("Oluşturulma tarihi alanı zorunludur.");
            RuleFor(composer => composer.IsActive).NotEmpty().WithMessage("Aktif mi alanı zorunludur.");
        }
    }
}
