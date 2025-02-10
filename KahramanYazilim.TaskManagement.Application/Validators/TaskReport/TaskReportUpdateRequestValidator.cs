using FluentValidation;
using KahramanYazilim.TaskManagement.Application.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahramanYazilim.TaskManagement.Application.Validators.TaskReport
{
    public class TaskReportUpdateRequestValidator : AbstractValidator<TaskReportUpdateRequest>
    {
        public TaskReportUpdateRequestValidator()
        {
            this.RuleFor(x => x.Detail).NotEmpty().WithMessage("Açıklama bilgisi boş olamaz");
            this.RuleFor(x => x.Definition).NotEmpty().WithMessage("Başlık bilgisi boş olamaz");

        }
    }
}
