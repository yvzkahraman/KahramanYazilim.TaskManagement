using KahramanYazilim.TaskManagement.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KahramanYazilim.TaskManagement.UI.Controllers.Admin
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> List(string? s, int activePage = 1)
        {
            ViewBag.s = s;
            ViewBag.Active = "Members";
            var result = await this.mediator.Send(new MemberListPagedRequest(activePage, s));
            return View(result);
        }

        public async Task<IActionResult> ResetPassword(int id)
        {
            await this.mediator.Send(new MemberResetPasswordRequest(id));
            return RedirectToAction("List");
        }

        public async Task<IActionResult> Update(int id)
        {
            var result = await this.mediator.Send(new MemberGetByIdRequest(id));
            return View(new MemberUpdateRequest(result.Data.Id, result.Data.Name, result.Data.Surname));
        }

        [HttpPost]
        public async Task<IActionResult> Update(MemberUpdateRequest request)
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
                    ModelState.AddModelError("", result.ErrorMessage ?? "Sistemsel bir hata oluştu, üreticinize başvurun");
                }
            }


            return View(request);
        }

        public async Task<IActionResult> UserDetail()
        {
            ViewBag.Active = "Profil";
            var userId = int.Parse(User.Claims.SingleOrDefault(x => x.Type == "UserId")?.Value ?? "0");
            var updated = await this.mediator.Send(new UserDetailRequest(userId));
            return View(new UserDetailUpdateRequest(updated.Data.Id, updated.Data.Name,updated.Data.Surname,updated.Data.Password));
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
        public IActionResult Create()
        {
         
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MemberCreateRequest request)
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
                    ModelState.AddModelError("", result.ErrorMessage ?? "Sistemsel bir hata oluştu, üreticinize başvurun");
                }
            }


            return View(request);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.mediator.Send(new MemberDeleteRequest(id));
            return RedirectToAction("List");
        }

    }
}
