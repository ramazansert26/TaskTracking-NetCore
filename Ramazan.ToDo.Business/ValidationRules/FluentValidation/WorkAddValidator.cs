using FluentValidation;
using Ramazan.ToDo.DTO.DTOs.WorkDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ramazan.ToDo.Business.ValidationRules.FluentValidation
{
    public class WorkAddValidator: AbstractValidator<WorkAddDto>
    {
        public WorkAddValidator()
        {
            RuleFor(I => I.Name).NotNull().WithMessage("Ad alanı boş geçilemez");
            RuleFor(I => I.PriorityId).ExclusiveBetween(0, int.MaxValue).WithMessage("Lütfen bir öncelik durumu seçiniz");
        }
    }
}
