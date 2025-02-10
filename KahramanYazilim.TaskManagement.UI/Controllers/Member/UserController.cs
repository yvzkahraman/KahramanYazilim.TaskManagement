using KahramanYazilim.TaskManagement.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KahramanYazilim.TaskManagement.UI.Controllers.Member
{
    [Area("Member")]
    [Authorize(Roles ="Member")]
    public class UserController : Controller
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> UserDetail()
        {
            ViewBag.Active = "Profil";
            var userId = int.Parse(User.Claims.SingleOrDefault(x => x.Type == "UserId")?.Value ?? "0");
            var updated = await this.mediator.Send(new UserDetailRequest(userId));
            return View(new UserDetailUpdateRequest(updated.Data.Id, updated.Data.Name, updated.Data.Surname, updated.Data.Password));
        }

        [HttpPost]
        public async Task<IActionResult> UserDetail(UserDetailUpdateRequest request)
        {
            ViewBag.Active = "Profil";

            var result = await this.mediator.Send(request);

            if (result.IsSuccess)
            {
                return RedirectToAction("UserDetail");
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
                    ModelState.AddModelError("", result.ErrorMessage ?? "Sistemsel bir hata oluştu, üreticinize başvurun");
                }
            }


            return View(request);


        }
    }
}
