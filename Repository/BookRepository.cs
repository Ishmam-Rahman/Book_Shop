using BookStroe.Data;
using BookStroe.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookStroe.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDBContext _DBContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;
        public BookRepository(ApplicationDBContext DBContext, IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _DBContext = DBContext;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }

        public List<BookModel> GetAllBook()
        {
            return _DBContext.BookModel.ToList();
        }

        public List<BookModel> GetTopBooks()
        {
            return _DBContext.BookModel.Take(5).ToList();
        }
        public BookModel GetBookById(int? id)
        {
            BookModel book =  _DBContext.BookModel.Include(e=>e.booktype).Where(c => c.Id == id).FirstOrDefault();
            return book;
        }

        public List<BookModel> SearchBook(string title, string authorName)
        {
            return _DBContext.BookModel.Where(c => c.Title.Contains(title) || c.Author.Contains(authorName)).ToList();
        }

        public async Task<int> AddBook(BookModel book)
        {
            await _DBContext.BookModel.AddAsync(book);
            await _DBContext.SaveChangesAsync();
            return book.Id;
        }

        public async Task<int> UpdateBook(BookModel book)
        {

            _DBContext.BookModel.Update(book);
            await _DBContext.SaveChangesAsync();
            return book.Id;
        }

        public async Task<BookModel> RemoveBook(BookModel book)
        {
            BookModel Book = _DBContext.BookModel.Where(c => c.Id == book.Id).AsNoTracking().FirstOrDefault();
            string path = Path.Combine(_webHostEnvironment.WebRootPath, Book.PhotoURL.Remove(0, 1));
            string pdfpath = Path.Combine(_webHostEnvironment.WebRootPath, Book.PdfURL.Remove(0, 1));
            File.Delete(path);
            File.Delete(pdfpath);

            _DBContext.BookModel.Remove(book);
            await _DBContext.SaveChangesAsync();
            return book;
        }
        
    }
}
