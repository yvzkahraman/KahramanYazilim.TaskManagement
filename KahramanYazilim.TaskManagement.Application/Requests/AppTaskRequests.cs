using KahramanYazilim.TaskManagement.Application.Dtos;
using MediatR;


namespace KahramanYazilim.TaskManagement.Application.Requests
{
    public record AppTaskListRequest : PagedRequest, IRequest<PagedResult<AppTaskListDto>>
    {
        public AppTaskListRequest(int ActivePage) : base(ActivePage)
        {
        }
    }
}
