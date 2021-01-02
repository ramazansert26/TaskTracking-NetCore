using FluentValidation;
using Ramazan.ToDo.DTO.DTOs.PriorityDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ramazan.ToDo.Business.ValidationRules.FluentValidation
{
    public class PriorityUpdateValidator : AbstractValidator<PriorityUpdateDto>
    {
        public PriorityUpdateValidator()
        {
            RuleFor(I => I.Description).NotNull().WithMessage("Tanım alanı boş bırakılamaz");
        }
    }
}
