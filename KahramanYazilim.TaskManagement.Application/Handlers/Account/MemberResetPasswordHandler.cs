using KahramanYazilim.TaskManagement.Application.Dtos;
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
    public class MemberResetPasswordHandler : IRequestHandler<MemberResetPasswordRequest, Result<NoData>>
    {
        private readonly IUserRepository repository;

        public MemberResetPasswordHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<NoData>> Handle(MemberResetPasswordRequest request, CancellationToken cancellationToken)
        {
      
                var updated = await repository.GetByFilterAsync(x => x.Id == request.Id, false);
                if (updated == null)
                    return new Result<NoData>(new NoData(), false, "Member bulunamadı", null);


                updated.Password = "123";
               


                var rows = await repository.SaveChangesAsync();

                if (rows > 0)
                    return new Result<NoData>(new NoData(), true, null, null);

                return new Result<NoData>(new NoData(), false, "bir hata oluştu", null);
          


        }
    }
}
