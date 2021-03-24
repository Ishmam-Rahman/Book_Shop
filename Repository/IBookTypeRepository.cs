using BookStroe.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStroe.Repository
{
    public interface IBookTypeRepository
    {
        Task<int> CreateBookType(BookType type);
        List<BookType> getAllBookType();
        BookType getTypeById(int? ID);
        Task<int> Removetype(BookType bookType);
        Task<int> UpdateType(BookType bookType);
    }
}