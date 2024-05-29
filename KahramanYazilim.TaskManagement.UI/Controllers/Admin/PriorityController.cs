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

        public async Task<IActionResult> List()
        {
            var result = await this.mediator.Send(new PriorityListRequest());
            return View(result.Data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PriorityCreateRequest request)
        {
            var result = await this.mediator.Send(request);
            if (result.IsSuccess)
            {
                return RedirectToAction("List");
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

        public async Task<IActionResult> Delete(int id)
        {
            await this.mediator.Send(new PriorityDeleteRequest(id));
            return RedirectToAction("List");

        }

        public async Task<IActionResult> Update(int id)
        {
            var result = await this.mediator.Send(new PriorityGetByIdRequest(id));
            if (result.IsSuccess)
            {
                var requestModel = new PriorityUpdateRequest(result.Data.Id, result.Data.Definition);
                return View(requestModel);
            }
            else
            {
                ModelState.AddModelError("", result.ErrorMessage ?? "Bilinmeyen bir hata oluştu, sistem üreticinize başvurun");
                var requestModel = new PriorityUpdateRequest(0, null);
                return View(requestModel);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Update(PriorityUpdateRequest request)
        {
            var result = await this.mediator.Send(request);
            if (result.IsSuccess)
            {
                return RedirectToAction("List");
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
    }
}
