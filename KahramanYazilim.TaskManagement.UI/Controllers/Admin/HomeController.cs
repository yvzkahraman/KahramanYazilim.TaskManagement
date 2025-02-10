using KahramanYazilim.TaskManagement.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KahramanYazilim.TaskManagement.UI.Controllers.Admin
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly IMediator mediator;

        public HomeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var userId = int.Parse(User.Claims.SingleOrDefault(x => x.Type == "UserId")?.Value ?? "0");

            ViewBag.Active = "Home";

            var result = await this.mediator.Send(new DashboardRequest(userId));
            return View(result.Data);
        }
    }
}
