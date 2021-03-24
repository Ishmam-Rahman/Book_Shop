using BookStroe.Data;
using BookStroe.Models;
using BookStroe.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStroe.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository = null;
        private readonly BookTypeRepository _bookTypeRepository = null;
        public BookController(IBookRepository bookRepository, BookTypeRepository bookTypeRepository)
        {
            _bookRepository = bookRepository;
            _bookTypeRepository = bookTypeRepository;
        }

        public IActionResult GetAllBook()
        {
            var data= _bookRepository.GetAllBook();
            return View(data);
        }

        public IActionResult GetBookById(int id)
        {
            var book = _bookRepository.GetBookById(id);
            ViewData["BookTitle"] = (book.Title + " by " + book.Author);
            return View(book);
        }

        public IActionResult SearchBook(string title, string author)
        {
            return View("GetAllBook", _bookRepository.SearchBook(title, author).ToList());
        }

        public IActionResult AddBook()
        {
            ViewBag.BookTypeId = new SelectList(_bookTypeRepository.getAllBookType(),"Id", "TypeName") ;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BookModel Book)
        {
            int ID = await _bookRepository.AddBook(Book);
            if (ID > 0)
            {
                return RedirectToAction(nameof(GetBookById),new {id = Book.Id });
            }
            return View();
        }

        public IActionResult EditBook(int? id)
        {
            if (id == null) return NotFound();
            var bookdetails = _bookRepository.GetBookById(id);
            ViewData["BookTitle"] = (bookdetails.Title + " by " + bookdetails.Author);
            return View(bookdetails);
        }

        [HttpPost]
        public async Task<IActionResult> EditBook(BookModel book)
        {
            int ID = await _bookRepository.UpdateBook(book);
            
            if (ID > 0)
            {
                return RedirectToAction(nameof(GetBookById), new { id = book.Id });
            }
            return View(book);
        }

        public IActionResult DeleteBook(int? ID)
        {
            var bookdetails = _bookRepository.GetBookById(ID);
            ViewData["BookTitle"] = (bookdetails.Title + " by " + bookdetails.Author);
            return View(bookdetails);
        }
        
        [HttpPost]
        public async Task<IActionResult> DeleteBook(BookModel book)
        {
           await _bookRepository.RemoveBook(book);

            return RedirectToAction(nameof(GetAllBook));
        }
        
    }
}
