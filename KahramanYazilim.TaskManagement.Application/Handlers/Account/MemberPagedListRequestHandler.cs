using KahramanYazilim.TaskManagement.Application.Dtos;
using KahramanYazilim.TaskManagement.Application.Interfaces;
using KahramanYazilim.TaskManagement.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahramanYazilim.TaskManagement.Application.Handlers.Account
{
    public class MemberPagedListRequestHandler : IRequestHandler<MemberListPagedRequest, PagedResult<MemberListDto>>
    {
        private readonly IUserRepository repository;

        public MemberPagedListRequestHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<PagedResult<MemberListDto>> Handle(MemberListPagedRequest request, CancellationToken cancellationToken)
        {
            var result = await this.repository.GetAllAsync(request.ActivePage, request.S, 10);
            var mappedData = result.Data.Select(x => new MemberListDto(x.Id, x.Name, x.Surname, x.Username)).ToList();
            return new PagedResult<MemberListDto>(mappedData, request.ActivePage, result.PageSize, result.TotalPages);
        }
    }
}
