using BookStroe.Data;
using BookStroe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStroe.Repository
{
    public class BookTypeRepository : IBookTypeRepository
    {
        private readonly ApplicationDBContext _DBContext;
        public BookTypeRepository(ApplicationDBContext applicationDBContext)
        {
            _DBContext = applicationDBContext;
        }

        public async Task<int> CreateBookType(BookType type)
        {
            await _DBContext.BookType.AddAsync(type);
            await _DBContext.SaveChangesAsync();
            return type.Id;
        }

        public List<BookType> getAllBookType()
        {
            return _DBContext.BookType.ToList();
        }

        public BookType getTypeById(int? ID)
        {
            return _DBContext.BookType.Where(c => c.Id == ID).FirstOrDefault();
        }

        public async Task<int> UpdateType(BookType bookType)
        {
            _DBContext.BookType.Update(bookType);
            await _DBContext.SaveChangesAsync();
            return bookType.Id;
        }

        public async Task<int> Removetype(BookType bookType)
        {
            _DBContext.BookType.Remove(bookType);
            await _DBContext.SaveChangesAsync();
            return 0;
        }

    }
}
