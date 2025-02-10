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
    public class UserDetailRequestHandler : IRequestHandler<UserDetailRequest, Result<UserDetailDto>>
    {
        private readonly IUserRepository repository;

        public UserDetailRequestHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<UserDetailDto>> Handle(UserDetailRequest request, CancellationToken cancellationToken)
        {
            var result = await this.repository.GetByFilterAsync(x=>x.Id == request.Id);

            var mappedData = new UserDetailDto(result.Id, result.Name, result.Surname, result.Password);
          
            return new Result<UserDetailDto>(mappedData,true,null,null);
        }
    }
}
