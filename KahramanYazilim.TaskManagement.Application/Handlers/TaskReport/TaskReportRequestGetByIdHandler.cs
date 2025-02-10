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
    public class TaskReportRequestGetByIdHandler : IRequestHandler<TaskReportGetByIdRequest, Result<TaskReportListDto>>
    {
        private readonly ITaskReportRepository repository;

        public TaskReportRequestGetByIdHandler(ITaskReportRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<TaskReportListDto>> Handle(TaskReportGetByIdRequest request, CancellationToken cancellationToken)
        {
            var result = await this.repository.GetByFilter(x => x.Id == request.Id, false);
            return new Result<TaskReportListDto>(new TaskReportListDto(result.Id,result.Definition,result.Detail,result.AppTaskId, result.AppTask?.Title  ), true, null, null);
        }
    }
}
