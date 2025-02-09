using KahramanYazilim.TaskManagement.Application.Dtos;
using KahramanYazilim.TaskManagement.Application.Enums;
using KahramanYazilim.TaskManagement.Application.Extensions;
using KahramanYazilim.TaskManagement.Application.Interfaces;
using KahramanYazilim.TaskManagement.Application.Requests;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahramanYazilim.TaskManagement.Application.Handlers.TaskReport
{
    public class TaskReportRequestHandler : IRequestHandler<TaskReportGetByTaskIdRequest, Result<List<TaskReportListDto>>>
    {
        private readonly ITaskReportRepository repository;

        public TaskReportRequestHandler(ITaskReportRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<List<TaskReportListDto>>> Handle(TaskReportGetByTaskIdRequest request, CancellationToken cancellationToken)
        {
            var result = await this.repository.GetAllByFilterAsync(x => x.AppTaskId == request.Id, false);
            return new Result<List<TaskReportListDto>>(result.ToMap(), true, null, null);
        }
    }
}
