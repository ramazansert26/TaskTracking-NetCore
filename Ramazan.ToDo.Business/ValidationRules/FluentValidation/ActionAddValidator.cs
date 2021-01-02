using FluentValidation;
using Ramazan.ToDo.DTO.DTOs.ActionDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ramazan.ToDo.Business.ValidationRules.FluentValidation
{
    public class ActionAddValidator : AbstractValidator<ActionAddDto>
    {
        public ActionAddValidator()
        {
            RuleFor(I => I.Description).NotNull().WithMessage("Tanım alanı boş geçilemez.");
            RuleFor(I => I.Detail).NotNull().WithMessage("Detay alanı boş geçilemez.");
            RuleFor(I => I.TimeSpent).NotNull().WithMessage("Harcanan Süre alanı boş geçilemez.").ExclusiveBetween(1,8).WithMessage("Harcanan Süre alanına 1 ile 8 saat arası girilebilir.");
        }
    }
}
