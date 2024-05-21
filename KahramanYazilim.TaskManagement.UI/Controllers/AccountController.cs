using KahramanYazilim.TaskManagement.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using KahramanYazilim.TaskManagement.Application.Dtos;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace KahramanYazilim.TaskManagement.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMediator mediator;

        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginRequest("", ""));
        }

        //Custom cookie based auth.
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var result = await this.mediator.Send(request);
            if (result.IsSuccess && result.Data != null)
            {
                await SetAuthCookie(result.Data, request.RememberMe);

                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            else
            {
                if (result.Errors != null && result.Errors.Count > 0)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                }
                else
                {
                    ModelState.AddModelError("", result.ErrorMessage ?? "Bilinmeyen bir hata oluştu, sistem üreticinize başvurun.");
                }

                return View(request);
            }
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var result = await this.mediator.Send(request);
            if (result.IsSuccess)
            {
                return RedirectToAction("Login");
            }
            else
            {
                if (result.Errors != null && result.Errors.Count > 0)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                }
                else
                {
                    ModelState.AddModelError("", result.ErrorMessage ?? "Bilinmeyen bir hata oluştu, sistem üreticinize  başvurun");
                }
                return View(request);
            }

        }

        public IActionResult LogOut()
        {
            return View();
        }


        private async Task SetAuthCookie(LoginResponseDto dto, bool rememberMe)
        {
            // User => 

            User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Name);

            var claims = new List<Claim>
        {
            new Claim("Name", dto.Name),
            new Claim("Surname", dto.Surname),
            new Claim(ClaimTypes.Role, dto.Role.ToString()),
        };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                //AllowRefresh = <bool>,
                // Refreshing the authentication session should be allowed.

                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(30),
                // The time at which the authentication ticket expires. A 
                // value set here overrides the ExpireTimeSpan option of 
                // CookieAuthenticationOptions set with AddCookie.

                IsPersistent = rememberMe,
                // Whether the authentication session is persisted across 
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.

                //IssuedUtc = <DateTimeOffset>,
                // The time at which the authentication ticket was issued.

                //RedirectUri = <string>
                // The full path or absolute URI to be used as an http 
                // redirect response value.
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }
    }
}
