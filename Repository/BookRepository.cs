using BookStroe.Data;
using BookStroe.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStroe.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDBContext _DBContext;
        public BookRepository(ApplicationDBContext DBContext)
        {
            _DBContext = DBContext;
        }

        public List<BookModel> GetAllBook()
        {
            return _DBContext.BookModel.ToList();
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
            _DBContext.BookModel.Remove(book);
            await _DBContext.SaveChangesAsync();
            return book;
        }


        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id=1, Title="MVC", Author="Ishmam", Description="Learn MVC", Pages=100},
                new BookModel(){Id=2, Title="C#", Author="Riya", Description="Learn C#", Pages=110},
                new BookModel(){Id=3, Title="Python", Author="Zakir", Description="Learn python", Pages=200},
                new BookModel(){Id=4, Title="API", Author="Akash", Description="Learn REST API", Pages=140},
            };
        }
    }
}
