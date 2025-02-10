using KahramanYazilim.TaskManagement.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

    }
}
