using KahramanYazilim.TaskManagement.Application.Dtos;
using MediatR;


namespace KahramanYazilim.TaskManagement.Application.Requests
{
    public record AppTaskListRequest : PagedRequest, IRequest<PagedResult<AppTaskListDto>>
    {
        public AppTaskListRequest(int activePage, string s) : base(activePage)
        {
            S = s;
        }
        public string? S { get; set; }
    }



    public record AppTaskCreateRequest(string? Title, string? Description, int PriorityId) : IRequest<Result<AppTaskDto>>;
}
