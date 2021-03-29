using BookStroe.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStroe.Repository
{
    public interface IBookRepository
    {
        Task<int> AddBook(BookModel book);
        List<BookModel> GetAllBook();
        BookModel GetBookById(int? id);
        Task<BookModel> RemoveBook(BookModel book);
        List<BookModel> SearchBook(string title, string authorName);
        Task<int> UpdateBook(BookModel book);
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        List<BookModel> GetTopBooks();
    }
}