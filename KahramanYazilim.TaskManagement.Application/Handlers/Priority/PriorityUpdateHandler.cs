using KahramanYazilim.TaskManagement.Application.Dtos;
using KahramanYazilim.TaskManagement.Application.Extensions;
using KahramanYazilim.TaskManagement.Application.Interfaces;
using KahramanYazilim.TaskManagement.Application.Requests;
using KahramanYazilim.TaskManagement.Application.Validators.Priority;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahramanYazilim.TaskManagement.Application.Handlers
{
    public class PriorityUpdateHandler : IRequestHandler<PriorityUpdateRequest, Result<NoData>>
    {
        private readonly IPriorityRepository repository;

        public PriorityUpdateHandler(IPriorityRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<NoData>> Handle(PriorityUpdateRequest request, CancellationToken cancellationToken)
        {

            var validator =  new PriorityUpdateRequestValidator();
            var validationResult = validator.Validate(request);

            if (validationResult.IsValid)
            {
                var updatedEnity = await this.repository.GetByFilterAsync(x => x.Id == request.Id);
                if (updatedEnity == null)
                    return new Result<NoData>(new NoData(), false, "İlgili aciliyet bulunamadı", null);

                updatedEnity.Definition = request.Definition ?? "";

                await this.repository.SaveChangesAsync();
                return new Result<NoData>(new NoData(), true, null, null);

            }
            else
            {
                var errors = validationResult.Errors.ToMap();
                return new Result<NoData>(new NoData(), false, null, errors);
            }


     
        }
    }
}
