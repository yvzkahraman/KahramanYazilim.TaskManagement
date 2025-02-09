using FluentValidation;
using KahramanYazilim.TaskManagement.Application.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahramanYazilim.TaskManagement.Application.Validators.AppTask
{
    public class AppTaskUpdateRequestValidator : AbstractValidator<AppTaskUpdateRequest>
    {
        public AppTaskUpdateRequestValidator()
        {
            this.RuleFor(x => x.PriorityId).NotEmpty().WithMessage("Öncelik bilgisi boş geçilemez");
            this.RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık bilgisi boş olamaz");
            this.RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama bilgisi boş olamaz");
        }
    }
}
