using KahramanYazilim.TaskManagement.Application.Dtos;
using KahramanYazilim.TaskManagement.Application.Enums;
using KahramanYazilim.TaskManagement.Application.Extensions;
using KahramanYazilim.TaskManagement.Application.Interfaces;
using KahramanYazilim.TaskManagement.Application.Requests;
using KahramanYazilim.TaskManagement.Application.Validators;
using KahramanYazilim.TaskManagement.Application.Validators.Account;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahramanYazilim.TaskManagement.Application.Handlers.Account
{
    public class MemberCreateHandler : IRequestHandler<MemberCreateRequest, Result<NoData>>
    {
        private readonly IUserRepository repository;

        public MemberCreateHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<NoData>> Handle(MemberCreateRequest request, CancellationToken cancellationToken)
        {
            var validator = new MemberCreateRequestValidator();
            var validationResult = validator.Validate(request);

            if (validationResult.IsValid)
            {
                var rows = await this.repository.CreateUserAsync(new Domain.Entities.AppUser
                {
                    AppRoleId = (int)RoleType.Member,
                    Name = request.Name,
                    Password = "123",
                    Surname = request.Surname,
                    Username = request.Username,

                });
                if (rows > 0)
                    return new Result<NoData>(new NoData(), true, null, null);

                return new Result<NoData>(new NoData(), false, "bir hata oluştu", null);
            }
            else
            {
                return new Result<NoData>(new NoData(), false, null, validationResult.Errors.ToMap());
            }

        }
    }
}
