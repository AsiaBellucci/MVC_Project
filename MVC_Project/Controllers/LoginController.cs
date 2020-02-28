using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_Project.Models.Entities;
using MVC_Project.Models.Services.Interfaces;
using MVC_Project.Models.ViewModels;

namespace MVC_Project.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _user;

        public LoginController (IUserService user)
        {
            this._user = user;
        }

        

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Verify([FromForm]UserViewModel userView)
        {
            if (!ModelState.IsValid)
            {
                return View("Login");
            }

            IUserService user1 = _user;
            bool UserList =  user1.DoLogin(userView.Name, userView.Password);
            if (UserList == true)
                return View(UserList);
            else
            {
                this.ModelState.Clear();// per cancellare le scritte dai campi
                ViewBag.PopupMessage = "request_failed";
                return View("Login");
            }
        }
    }
}