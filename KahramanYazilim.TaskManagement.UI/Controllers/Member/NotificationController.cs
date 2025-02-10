using KahramanYazilim.TaskManagement.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KahramanYazilim.TaskManagement.UI.Controllers.Member
{
    [Area("Member")]
    [Authorize(Roles ="Member")]
    public class NotificationController : Controller
    {
        private readonly IMediator mediator;

        public NotificationController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> List()
        {
            ViewBag.Active = "Notification";
            var userId = int.Parse(User.Claims.SingleOrDefault(x => x.Type == "UserId")?.Value ?? "0");
            var result = await this.mediator.Send(new NotificationListByUserIdRequest(userId));
            return View(result.Data);
        }

        public async Task<IActionResult> Update(int id)
        {
            await this.mediator.Send(new NotificationUpdateRequest(id));
            return RedirectToAction("List");
        }
    }
}
