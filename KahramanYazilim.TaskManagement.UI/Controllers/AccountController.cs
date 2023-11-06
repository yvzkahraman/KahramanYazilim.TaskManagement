using KahramanYazilim.TaskManagement.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace KahramanYazilim.TaskManagement.UI.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //c# 9.0 record 
        [HttpPost]
        public IActionResult Login(LoginDto dto)
        {
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
