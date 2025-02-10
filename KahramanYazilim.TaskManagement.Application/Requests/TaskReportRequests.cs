using KahramanYazilim.TaskManagement.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KahramanYazilim.TaskManagement.Application.Requests
{
    public record TaskReportGetByTaskIdRequest(int Id) : IRequest<Result<List<TaskReportListDto>>>;

    public record TaskReportGetByIdRequest(int Id) : IRequest<Result<TaskReportListDto>>;

    public record TaskReportCreateRequest(string? Detail, string? Definition, int TaskId) : IRequest<Result<NoData>>;

    public record TaskReportUpdateRequest(int Id, string? Detail, string? Definition, int TaskId) : IRequest<Result<NoData>>;
}
