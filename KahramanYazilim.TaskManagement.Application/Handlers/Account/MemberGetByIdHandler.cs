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
    public class MemberGetByIdHandler : IRequestHandler<MemberGetByIdRequest, Result<MemberListDto>>
    {
        private readonly IUserRepository repository;

        public MemberGetByIdHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<MemberListDto?>> Handle(MemberGetByIdRequest request, CancellationToken cancellationToken)
        {
            var result = await this.repository.GetByFilterAsync(x => x.Id == request.Id);

            if (result != null)
                return new Result<MemberListDto?>(new MemberListDto(result.Id, result.Name, result.Surname, result.Username), true, null, null);
            return new Result<MemberListDto?>(null, false, "", null);
        }
    }
}
