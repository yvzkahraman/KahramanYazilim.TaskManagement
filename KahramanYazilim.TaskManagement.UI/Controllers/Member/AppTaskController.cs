using KahramanYazilim.TaskManagement.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace KahramanYazilim.TaskManagement.UI.Controllers.Member
{
    [Area("Member")]
    [Authorize(Roles="Member")]
    public class AppTaskController : Controller
    {
        private readonly IMediator mediator;

        public AppTaskController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> List(string? s, int activePage = 1)
        {
            var userId = int.Parse( User.Claims.SingleOrDefault(x => x.Type == "UserId")?.Value ?? "0");
            ViewBag.s = s;
            ViewBag.Active = "AppTask";
            var result = await this.mediator.Send(new AppTaskListByUserIdRequest(activePage, s,userId));
            return View(result);
        }

        public async Task<IActionResult> ReportList(int id)
        {
            var appTaskInfo = await this.mediator.Send(new AppTaskGetByIdRequest(id));
            ViewBag.TaskTitle = appTaskInfo.Data.Title;
            ViewBag.TaskId = appTaskInfo.Data.Id;
            var result = await this.mediator.Send(new TaskReportGetByTaskIdRequest(id));

            return View(result.Data);
        }

        public IActionResult CreateReport(int taskId)
        {
            ViewBag.Active = "AppTask";
            return View(new TaskReportCreateRequest("","",taskId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateReport(TaskReportCreateRequest request)
        {
 
            ViewBag.Active = "AppTask";
            var result = await this.mediator.Send(request);
            if (result.IsSuccess)
            {
                return RedirectToAction("ReportList", new { id = request.TaskId });
            }
            else
            {
                if (result.Errors?.Count > 0)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                }
                else
                {
                    ModelState.AddModelError("", result.ErrorMessage ?? "Bilinmeyen bir hata oluştu, sistem üreticinize başvurun");
                }

                return View(request);
            }
        }


        public async Task<IActionResult> UpdateReport(int id)
        {
            var result = await this.mediator.Send(new TaskReportGetByIdRequest(id));
            return View(new TaskReportUpdateRequest(result.Data.Id, result.Data.Detail, result.Data.Definition, result.Data.AppTaskId));
        }

       [HttpPost]
        public async Task<IActionResult> UpdateReport(TaskReportUpdateRequest request)
        {
            ViewBag.Active = "AppTask";
            var result = await this.mediator.Send(request);
            if (result.IsSuccess)
            {

                return RedirectToAction("ReportList", new { id = request.TaskId });
            }
            else
            {
                ModelState.AddModelError("", result.ErrorMessage ?? "Bilinmeyen bir hata oluştu, sistem üreticinize başvurun");
             
                return View(request);
            }

        }

    }
}
