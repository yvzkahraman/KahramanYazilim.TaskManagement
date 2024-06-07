using KahramanYazilim.TaskManagement.Application.Dtos;
using KahramanYazilim.TaskManagement.Application.Extensions;
using KahramanYazilim.TaskManagement.Application.Interfaces;
using KahramanYazilim.TaskManagement.Application.Requests;
using KahramanYazilim.TaskManagement.Application.Validators;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahramanYazilim.TaskManagement.Application.Handlers.AppTask
{
    public class AppTaskCreateHandler : IRequestHandler<AppTaskCreateRequest, Result<AppTaskDto>>
    {
        private readonly IAppTaskRepository repository;
        private readonly IPriorityRepository priorityRepository;

        public AppTaskCreateHandler(IAppTaskRepository repository, IPriorityRepository priorityRepository)
        {
            this.repository = repository;
            this.priorityRepository = priorityRepository;
        }

        public async Task<Result<AppTaskDto>> Handle(AppTaskCreateRequest request, CancellationToken cancellationToken)
        {
            var priorities = await this.priorityRepository.GetAllAsync();

            var priorityDtoList = priorities.Select(x => new PriorityListDto(x.Id, x.Definition)).ToList();

            var validator = new AppTaskCreateRequestValidator();
            var validationResult = validator.Validate(request);

            if (validationResult.IsValid)
            {
                var rows = await this.repository.CreateAsync(request.ToMap());

                if (rows > 0)
                    return new Result<AppTaskDto>(new AppTaskDto(priorityDtoList), true, null, null);

                return new Result<AppTaskDto>(new AppTaskDto(priorityDtoList), false, "bir hata oluştu", null);
            }
            else
            {
                return new Result<AppTaskDto>(new AppTaskDto(priorityDtoList), false, null, validationResult.Errors.ToMap());
            }
        }
    }
}
