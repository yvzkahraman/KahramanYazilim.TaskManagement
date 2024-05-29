using KahramanYazilim.TaskManagement.Application.Dtos;
using KahramanYazilim.TaskManagement.Application.Interfaces;
using KahramanYazilim.TaskManagement.Application.Requests;
using MediatR;

namespace KahramanYazilim.TaskManagement.Application.Handlers
{
    public class AppTaskListHandler : IRequestHandler<AppTaskListRequest, PagedResult<AppTaskListDto>>
    {
        private readonly IAppTaskRepository repository;

        public AppTaskListHandler(IAppTaskRepository repository)
        {
            this.repository = repository;
        }

        public async Task<PagedResult<AppTaskListDto>> Handle(AppTaskListRequest request, CancellationToken cancellationToken)
        {
            var list = await this.repository.GetAllAsync(request.ActivePage);

            var result = new List<AppTaskListDto>();

            foreach (var appTask in list.Data)
            {

                var dto = new AppTaskListDto(appTask.Id, appTask.Title, appTask.Description, appTask.Priority?.Definition, appTask.State);
                result.Add(dto);
            }

            return new PagedResult<AppTaskListDto>(result,request.ActivePage,list.PageSize,list.TotalPages);
        }
    }
}
