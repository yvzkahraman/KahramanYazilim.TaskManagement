using FluentValidation;
using KahramanYazilim.TaskManagement.Application.Requests;

namespace KahramanYazilim.TaskManagement.Application.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            this.RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez");
            this.RuleFor(x => x.Password).NotEmpty().WithMessage("Parola boş geçilemez");
        }
    }
}
