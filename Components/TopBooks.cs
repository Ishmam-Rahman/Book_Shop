using BookStroe.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStroe.Components
{
    public class TopBooks : ViewComponent
    {
        private readonly IBookRepository _bookRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment = null;
        
        public TopBooks(IBookRepository bookRepository, IWebHostEnvironment webHostEnvironment)
        {
            _bookRepository = bookRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var restult = _bookRepository.GetTopBooks();
            return View("TopBooks",restult);
        }
    }
}
