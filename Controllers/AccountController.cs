using BookStroe.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStroe.Controllers
{
    public class AccountController : Controller
    {
        [Route("signup")]
        public IActionResult Signup()
        {
            return View();
        }

        [Route("signup")]
        [HttpPost]
        public IActionResult Signup(SignUpUserViewModel usermodel)
        {
            if (ModelState.IsValid)
            {
                ModelState.Clear();
            }
            return View();
        }
    }
}
