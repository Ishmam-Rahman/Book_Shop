using BookStroe.Data;
using BookStroe.Models;
using BookStroe.Services;
using BookStroe.Utility;
using BookStroe.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BookStroe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;
        private readonly ApplicationDBContext _applicationDBContext;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IEmailService emailService, ApplicationDBContext applicationDBContext)
        {
            _logger = logger;
            _configuration = configuration;
            _emailService = emailService;
            _applicationDBContext = applicationDBContext;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["sort"] = _configuration["sortbook"];

            //UserEmailOptions options = new UserEmailOptions
            //{
            //    ToEmails = new List<string>() { "ishmam64@gmail.com" }
            //};

            //await _emailService.SendTestEmail(options);

            return View();
 
        }

        //[HttpPost]
        public IActionResult AddToCart(int? id)
        {
            var book = _applicationDBContext.BookModel.Include(c => c.booktype).FirstOrDefault(x => x.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            List<BookModel> books = new List<BookModel>();
            books = HttpContext.Session.Get<List<BookModel>>("books");
            if (books == null)
            {
                books = new List<BookModel>();
            }
            books.Add(book);
            HttpContext.Session.Set("books", books);

            return RedirectToAction(nameof(Index));
        }

        //[HttpPost]
        public IActionResult RemoveFromCart(int? id)
        {
            List<BookModel> books = new List<BookModel>();
            books = HttpContext.Session.Get<List<BookModel>>("books");

            if (books != null)
            {
                var book = books.FirstOrDefault(c => c.Id == id);
                if (book != null)
                {
                    books.Remove(book);
                    HttpContext.Session.Set("books", books);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Cart()
        {
            List<BookModel> books = HttpContext.Session.Get<List<BookModel>>("books");
            if (books == null)
            {
                books = new List<BookModel>();
            }
            return View(books);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
