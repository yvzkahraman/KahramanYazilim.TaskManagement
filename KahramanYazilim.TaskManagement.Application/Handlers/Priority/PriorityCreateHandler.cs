using KahramanYazilim.TaskManagement.Application.Dtos;
using KahramanYazilim.TaskManagement.Application.Extensions;
using KahramanYazilim.TaskManagement.Application.Interfaces;
using KahramanYazilim.TaskManagement.Application.Requests;
using KahramanYazilim.TaskManagement.Application.Validators;
using MediatR;

namespace KahramanYazilim.TaskManagement.Application.Handlers
{
    public class PriorityCreateHandler : IRequestHandler<PriorityCreateRequest, Result<NoData>>
    {
        private readonly IPriorityRepository repository;

        public PriorityCreateHandler(IPriorityRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<NoData>> Handle(PriorityCreateRequest request, CancellationToken cancellationToken)
        {
            var validator = new PriorityCreateRequestValidator();
            var validationResult = validator.Validate(request);


            if (validationResult.IsValid)
            {
                var rowCount = await this.repository.CreateAsync(request.ToMap());
                if(rowCount > 0) {
                    return new Result<NoData>(new NoData(),true,null,null);
                }
                return new Result<NoData>(new NoData(), false, "Sistemsel bir hata oluştu, sistem üreticinize başvurun", null);
            }
            else
            {
                var errors = validationResult.Errors.ToMap();
                return new Result<NoData>(new NoData(),false, null, errors);
            }

        }
    }
}
