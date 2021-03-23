using BookStroe.Models;
using BookStroe.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStroe.Controllers
{
    public class BookTypeController : Controller
    {
        private readonly BookTypeRepository _bookTypeReository;
        
        public BookTypeController(BookTypeRepository bookTypeRepository)
        {
            _bookTypeReository = bookTypeRepository;
        }

        public IActionResult AddBookType()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBookType(BookType booktype)
        {
            await _bookTypeReository.CreateBookType(booktype);
            return RedirectToAction("AllBookType");
        }

        public IActionResult AllBookType()
        {
            return View(_bookTypeReository.getAllBookType());
        }

        public IActionResult BookTypeById(int id)
        {
            var booktype = _bookTypeReository.getTypeById(id);
            
            return View(booktype);
        }

        public IActionResult EditBookType(int? ID)
        {
            return View(_bookTypeReository.getTypeById(ID));
        }
        [HttpPost]
        public async Task<IActionResult> EditBookType(BookType bookType)
        {
            int ID =await _bookTypeReository.UpdateType(bookType);

            if (ID > 0)
            {
                return RedirectToAction(nameof(BookTypeById), new { id = bookType.Id });
            }
            return View(bookType);
        }

        public IActionResult DeleteBookType(int? ID)
        {
            return View(_bookTypeReository.getTypeById(ID));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBookType(BookType bookType)
        {
            await _bookTypeReository.Removetype(bookType);
            return RedirectToAction(nameof(AllBookType));
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
