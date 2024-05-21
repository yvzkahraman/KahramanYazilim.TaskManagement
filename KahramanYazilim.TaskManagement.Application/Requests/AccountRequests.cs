﻿using KahramanYazilim.TaskManagement.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahramanYazilim.TaskManagement.Application.Requests
{

    public record LoginRequest(string? Username, string? Password, bool RememberMe = false) : IRequest<Result<LoginResponseDto?>>;

    public record RegisterRequest(string Username, string Password, string Name, string Surname): IRequest<Result<NoData>>;
}
