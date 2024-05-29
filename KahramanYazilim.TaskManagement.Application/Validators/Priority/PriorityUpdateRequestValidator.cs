using FluentValidation;
using KahramanYazilim.TaskManagement.Application.Requests;

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
