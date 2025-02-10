using KahramanYazilim.TaskManagement.Application.Dtos;
using KahramanYazilim.TaskManagement.Application.Interfaces;
using KahramanYazilim.TaskManagement.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahramanYazilim.TaskManagement.Application.Handlers.TaskReport
{
    public class TaskReportDeleteRequestHandler : IRequestHandler<TaskReportDeleteRequest, Result<NoData>>
    {
        private readonly ITaskReportRepository repository;

        public TaskReportDeleteRequestHandler(ITaskReportRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<NoData>> Handle(TaskReportDeleteRequest request, CancellationToken cancellationToken)
        {
            var deletedEntity = await this.repository.GetByFilter(x => x.Id == request.Id,false);
            if (deletedEntity != null)
            {
                await this.repository.DeleteAsync(deletedEntity);
                return new Result<NoData>(new NoData(), true, null, null);
            }
            return new Result<NoData>(new NoData(), false, "Silinecek rapor bulunamadı", null);
        }
    }
}
