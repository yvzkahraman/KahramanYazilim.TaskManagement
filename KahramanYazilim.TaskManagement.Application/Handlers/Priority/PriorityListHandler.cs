using KahramanYazilim.TaskManagement.Application.Dtos;
using KahramanYazilim.TaskManagement.Application.Interfaces;
using KahramanYazilim.TaskManagement.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahramanYazilim.TaskManagement.Application.Handlers
{
    public class PriorityListHandler : IRequestHandler<PriorityListRequest, Result<List<PriorityListDto>>>
    {
        private readonly IPriorityRepository repository;

        public PriorityListHandler(IPriorityRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<List<PriorityListDto>>> Handle(PriorityListRequest request, CancellationToken cancellationToken)
        {
            var result = await this.repository.GetAllAsync();

            var mappedResult = result.Select(x => new PriorityListDto(x.Id, x.Definition)).ToList();

            return new Result<List<PriorityListDto>>(mappedResult, true, null, null);
        }
    }
}
