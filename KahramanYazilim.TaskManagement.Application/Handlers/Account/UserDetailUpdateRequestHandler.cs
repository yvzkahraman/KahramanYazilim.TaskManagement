using KahramanYazilim.TaskManagement.Application.Dtos;
using KahramanYazilim.TaskManagement.Application.Extensions;
using KahramanYazilim.TaskManagement.Application.Interfaces;
using KahramanYazilim.TaskManagement.Application.Requests;
using KahramanYazilim.TaskManagement.Application.Validators.Account;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahramanYazilim.TaskManagement.Application.Handlers.Account
{
    public class UserDetailUpdateRequestHandler : IRequestHandler<UserDetailUpdateRequest, Result<NoData>>
    {
        private readonly IUserRepository repository;

        public UserDetailUpdateRequestHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<NoData>> Handle(UserDetailUpdateRequest request, CancellationToken cancellationToken)
        {
         
            var validator = new UserDetailUpdateRequestValidator();
            var validationResult = validator.Validate(request);

            if (validationResult.IsValid)
            {
                var updated = await this.repository.GetByFilterAsync(x => x.Id == request.Id, false);
                if (updated == null)
                    return new Result<NoData>(new NoData(), false, "User bulunamadı", null);

                updated.Name = request.Name;
                updated.Surname = request.Surname;
                updated.Password = request.Password;

               var rows =  await this.repository.SaveChangesAsync();
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
