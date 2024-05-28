using FluentValidation;
using KahramanYazilim.TaskManagement.Application.Requests;

namespace KahramanYazilim.TaskManagement.Application.Validators
{
    public class PriorityCreateRequestValidator : AbstractValidator<PriorityCreateRequest>
    {
        public PriorityCreateRequestValidator()
        {
            this.RuleFor(x => x.Definition).NotEmpty().WithMessage("Tanım alanı boş bırakılamaz");
        }
    }
}
