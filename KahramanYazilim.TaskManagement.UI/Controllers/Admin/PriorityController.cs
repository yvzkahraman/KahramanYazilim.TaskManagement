using KahramanYazilim.TaskManagement.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KahramanYazilim.TaskManagement.UI.Controllers.Admin
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PriorityController : Controller
    {
        private readonly IMediator mediator;

        public PriorityController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async  Task<IActionResult> List()
        {
            var result = await this.mediator.Send(new PriorityListRequest());
            return View(result.Data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PriorityCreateRequest request)
        {
            return View();
        }
    }
}
