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

namespace KahramanYazilim.TaskManagement.Application.Handlers.Account
{
    public class TaskReportRequestHandler : IRequestHandler<MemberListRequest, Result<List<MemberListDto>>>
    {
        private readonly IUserRepository userRepository;

        public TaskReportRequestHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<Result<List<MemberListDto>>> Handle(MemberListRequest request, CancellationToken cancellationToken)
        {
            var result = await this.userRepository.GetAllByFilterAsync(x => x.AppRoleId == (int)RoleType.Member, false);
            return new Result<List<MemberListDto>>(result.ToMap(), true, null, null);
        }
    }
}
