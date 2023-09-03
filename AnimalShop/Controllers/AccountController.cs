using AnimalShop.Models;
using AnimalShop.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AnimalShop.Controllers
{
    public class AccountController : Controller
    {
        private IAuthenticationRepository _authenticationRepository;


        public AccountController(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login model)
        {

            if (!ModelState.IsValid)
            {
                TempData["loginError"] = "Faild To Login, Please Check your input and try again";
                return RedirectToAction("Login");
            }
            var result = await _authenticationRepository.LogInAsync(model);
                if (result.Succeeded)
                {
                    return RedirectToAction("Administrator", "Administrator");
                }

            TempData["loginError"] = "UserName or Password is incorrect";
            return RedirectToAction("Login");

        }
        
        public async Task<IActionResult> Logout()
        {
            await _authenticationRepository.LogOutAsync();
            return RedirectToAction("MainMenu", "shop");
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }



        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Register model)
        {
            if (!ModelState.IsValid)
            {
                TempData["registrationError"] = "Faild To Register, Please Check your input and try again";
                return RedirectToAction("Register");
            }
       
            var registerResult  = await _authenticationRepository.AddUserAsync(model);

            if (registerResult.Succeeded)
            {

                var signInRes = await _authenticationRepository.LogInAsync(new Login { Username = model.Username, Password = model.Password});

                if (signInRes.Succeeded)
                {
                    return RedirectToAction("Administrator", "Administrator");
                }

                else
                {
                    TempData["registrationError"] = "Faild To Register, Please Check your input and try again";
                    return RedirectToAction("Register");
                }

            }

            return RedirectToAction("Register");
        }


    }
}
