using KahramanYazilim.TaskManagement.Application.Dtos;
using KahramanYazilim.TaskManagement.Application.Extensions;
using KahramanYazilim.TaskManagement.Application.Interfaces;
using KahramanYazilim.TaskManagement.Application.Requests;
using KahramanYazilim.TaskManagement.Application.Validators.Priority;
using KahramanYazilim.TaskManagement.Application.Validators.TaskReport;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahramanYazilim.TaskManagement.Application.Handlers.TaskReport
{
    public class TaskReportUpdateHandler : IRequestHandler<TaskReportUpdateRequest, Result<NoData>>
    {
        private readonly ITaskReportRepository repository;

        public TaskReportUpdateHandler(ITaskReportRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<NoData>> Handle(TaskReportUpdateRequest request, CancellationToken cancellationToken)
        {
            var validator = new TaskReportUpdateRequestValidator();
            var validationResult = validator.Validate(request);

            if (validationResult.IsValid)
            {
                var updatedEnity = await this.repository.GetByFilter(x => x.Id == request.Id,false);
                if (updatedEnity == null)
                    return new Result<NoData>(new NoData(), false, "Rapor bulunamadı", null);

                updatedEnity.Definition = request.Definition;
                updatedEnity.Detail = request.Detail;

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
