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
    public class LoginRequestHandler : IRequestHandler<LoginRequest, Result<LoginResponseDto>>
    {
        private readonly IUserRepository userRepository;

        public LoginRequestHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public Task<Result<LoginResponseDto>> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            // validation kontrol,
            // 

            throw new NotImplementedException();
        }
    }
}
