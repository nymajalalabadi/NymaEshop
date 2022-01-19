using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using NymaEshop2.Data.Repository;
using NymaEshop2.Models;
namespace NymaEshop2.Controllers
{
    public class AccountController : Controller
    {
        private IUserRepository _userrepository;

        public AccountController(IUserRepository userrepository)
        {
            _userrepository = userrepository;
        }


        public IActionResult Register()
        {

            return View();
        }


        [HttpPost]
        public IActionResult Register(RegisterViewModel register)
        {
            if(!ModelState.IsValid)
            {
                return View(register);
            }

            if (_userrepository.IsExistUserByEmail(register.Email.ToLower()))
            {
                ModelState.AddModelError("Email", "ایمیل وارد شده قبلا باهاش ثبت نام کرده است");

                return View(register);
            }

            Users user = new Users()
            {
                Email = register.Email.ToLower(),
                Password = register.Password,
                IsAdmin = false,
                RegisterDate = DateTime.Now
            };

            _userrepository.AddUser(user);
            return View("SuccessRegister",register);
        }





        public IActionResult Login()
        {
            return View();
        }




        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            if(!ModelState.IsValid)
            {
                return View(login);
            }

            var user = _userrepository.GetUserForLogin(login.Email.ToLower(), login.Password);

            if(user==null)
            {
                ModelState.AddModelError("Email", "ایمیل وارد شده قبلا باهاش ثبت نام کرده است");
                return View(login);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim("IsAdmin", user.IsAdmin.ToString()),
               // new Claim("CodeMeli", user.Email),

            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            var properties = new AuthenticationProperties
            {
                IsPersistent = login.Remeberme
            };

            HttpContext.SignInAsync(principal, properties);

            return Redirect("/");
        }


        public IActionResult Logout()
        {

            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("/Account/Login");
        }
    }
}
