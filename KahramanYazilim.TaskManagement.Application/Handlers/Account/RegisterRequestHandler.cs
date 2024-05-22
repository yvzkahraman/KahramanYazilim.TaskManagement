using KahramanYazilim.TaskManagement.Application.Dtos;
using KahramanYazilim.TaskManagement.Application.Extensions;
using KahramanYazilim.TaskManagement.Application.Interfaces;
using KahramanYazilim.TaskManagement.Application.Requests;
using KahramanYazilim.TaskManagement.Application.Validators;
using MediatR;

namespace KahramanYazilim.TaskManagement.Application.Handlers
{
    public class RegisterRequestHandler : IRequestHandler<RegisterRequest, Result<NoData>>
    {
        private readonly IUserRepository userRepository;

        public RegisterRequestHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<Result<NoData>> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            var validator = new RegisterRequestValidator();
            var validationResult = validator.Validate(request);

            if (validationResult.IsValid)
            {
                var rowCount = await this.userRepository.CreateUserAsync(request.ToMap());
                if (rowCount > 0)
                {
                    return new Result<NoData>(new NoData(), true, null, null);
                }
                return new Result<NoData>(new NoData(), false, "Bir sorun oluştu", null);
            }
            else
            {
                var errorList = validationResult.Errors.ToMap();
                return new Result<NoData>(new NoData(), false, null, errorList);
            }


        }
    }
}
