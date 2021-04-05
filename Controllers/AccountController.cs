using BookStroe.Repository;
using BookStroe.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStroe.Controllers
{
    
    public class AccountController : Controller
    {
        public readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [Route("signup")]
        public IActionResult Signup()
        {
            return View();
        }

        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> Signup(SignUpUserViewModel usermodel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.CreateUserAsync(usermodel);
                if (!result.Succeeded)
                {
                    foreach(var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }
                }
                return View(usermodel);
            }
            return RedirectToAction("Index", "Home");
        }

        [Route("signin")]
        public IActionResult Signin()
        {
            return View();
        }

        [Route("signin")]
        [HttpPost]
        public async Task<IActionResult> Signin(SignInUserViewModel usermodel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.PasswordSignInUserAsync(usermodel);
                if (result.Succeeded)
                {
                    if (! string.IsNullOrEmpty(returnUrl))
                    {
                        return LocalRedirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid info");
            }
            return View(usermodel);
        }

        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountRepository.Logout();
            return RedirectToAction("Index","Home");
        }


        [Authorize(Roles = "Admin")]
        public IActionResult CreateRole()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleViewModel usermodel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.RoleCreate(usermodel);
            }
            return View(usermodel);
        }

        [Route("change-password")]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.ChangePassword(model);
                if (result.Succeeded)
                {
                    ViewBag.IsSuccess = true;
                    ModelState.Clear();
                    return View();
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

    }
}
