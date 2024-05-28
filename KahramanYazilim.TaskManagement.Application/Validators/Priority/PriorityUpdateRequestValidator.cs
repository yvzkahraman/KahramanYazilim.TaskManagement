using FluentValidation;
using KahramanYazilim.TaskManagement.Application.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahramanYazilim.TaskManagement.Application.Validators.Priority
{
    public class PriorityUpdateRequestValidator : AbstractValidator<PriorityUpdateRequest>
    {
        public PriorityUpdateRequestValidator()
        {
            this.RuleFor(x => x.Definition).NotEmpty().WithMessage("Tanım bilgisi boş olamaz");
        }
    }
}
