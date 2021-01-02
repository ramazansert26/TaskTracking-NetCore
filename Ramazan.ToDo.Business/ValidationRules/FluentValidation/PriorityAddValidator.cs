using FluentValidation;
using Ramazan.ToDo.DTO.DTOs.PriorityDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ramazan.ToDo.Business.ValidationRules.FluentValidation
{
    public class PriorityAddValidator : AbstractValidator<PriorityAddDto>
    {
        public PriorityAddValidator()
        {
            RuleFor(I => I.Description).NotNull().WithMessage("Tanım alanı boş geçilemez");
        }
    }
}
