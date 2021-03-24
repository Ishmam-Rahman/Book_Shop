using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStroe.Models
{
    public class BookType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public ICollection<BookModel> BookModel { get; set; }
    }
}
