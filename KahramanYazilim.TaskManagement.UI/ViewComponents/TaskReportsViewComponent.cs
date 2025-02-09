using KahramanYazilim.TaskManagement.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KahramanYazilim.TaskManagement.UI.ViewComponents
{
    public class TaskReportsViewComponent : ViewComponent
    {
        private readonly IMediator mediator;

        public TaskReportsViewComponent(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public IViewComponentResult Invoke(int appTaskId)
        {
            var result = mediator.Send(new TaskReportGetByTaskIdRequest(appTaskId)).Result;
            return View(result.Data);
        }
    }
}
