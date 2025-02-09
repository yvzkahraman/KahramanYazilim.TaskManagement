using KahramanYazilim.TaskManagement.Application.Dtos;
using KahramanYazilim.TaskManagement.Application.Extensions;
using KahramanYazilim.TaskManagement.Application.Interfaces;
using KahramanYazilim.TaskManagement.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahramanYazilim.TaskManagement.Application.Handlers.AppTask
{
    public class AppTaskGetByIdHandler : IRequestHandler<AppTaskGetByIdRequest, Result<AppTaskListDto>>
    {
        private readonly IAppTaskRepository repository;

        public AppTaskGetByIdHandler(IAppTaskRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<AppTaskListDto>> Handle(AppTaskGetByIdRequest request, CancellationToken cancellationToken)
        {
            var result = await this.repository.GetByFilterAsNoTrackingAsync(x=>x.Id == request.Id);

            return new Result<AppTaskListDto>(result.ToMap(), true, null, null);
        }
    }
}
