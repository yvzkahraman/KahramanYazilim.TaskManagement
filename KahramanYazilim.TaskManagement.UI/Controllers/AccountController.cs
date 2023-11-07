using KahramanYazilim.TaskManagement.Application.Dtos;
using KahramanYazilim.TaskManagement.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
            return View();
        }

        //c# 9.0 record 
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest dto)
        {
            await this.mediator.Send(dto);

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult LogOut()
        {
            return View();
        }
    }
}
