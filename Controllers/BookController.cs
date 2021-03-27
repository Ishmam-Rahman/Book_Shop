using BookStroe.Data;
using BookStroe.Models;
using BookStroe.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System;


namespace BookStroe.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository = null;
        private readonly IBookTypeRepository _bookTypeRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment = null;
        private readonly ApplicationDBContext _DBContext;
        public BookController(ApplicationDBContext DBContext,IBookRepository bookRepository, IBookTypeRepository bookTypeRepository, IWebHostEnvironment webHostEnvironment)
        {
            _bookRepository = bookRepository;
            _bookTypeRepository = bookTypeRepository;
            _webHostEnvironment = webHostEnvironment;
            _DBContext = DBContext;
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
            if (Book.Photo != null)
            {
                string folder = "books/";
                folder += (Guid.NewGuid().ToString()+"_" + Book.Photo.FileName);
                Book.PhotoURL = "/"+folder;

                string serverfolder = Path.Combine( _webHostEnvironment.WebRootPath, folder);

                using (var fileStream = new FileStream(serverfolder, FileMode.Create))
                {
                    await Book.Photo.CopyToAsync(fileStream);
                }
                //await Book.Photo.CopyToAsync(new FileStream(serverfolder,FileMode.Create));
            }


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

            ViewBag.BookTypeId = new SelectList(_bookTypeRepository.getAllBookType(), "Id", "TypeName");
            var bookdetails = _bookRepository.GetBookById(id);
            ViewData["BookTitle"] = (bookdetails.Title + " by " + bookdetails.Author);
            return View(bookdetails);
        }

        [HttpPost]
        public async Task<IActionResult> EditBook(BookModel book)
        {
            if (book.Photo != null)
            {
                string path = Path.Combine(_webHostEnvironment.WebRootPath, book.PhotoURL.Remove(0, 1));
                System.IO.File.Delete(path);

                string folder = "books/";
                folder += (Guid.NewGuid().ToString() + "_" + book.Photo.FileName);
                book.PhotoURL = "/" + folder;

                string serverfolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                using (var fileStream = new FileStream(serverfolder, FileMode.Create))
                {
                    await book.Photo.CopyToAsync(fileStream);
                }
                //await book.Photo.CopyToAsync(new FileStream(serverfolder, FileMode.Create));
            }

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
