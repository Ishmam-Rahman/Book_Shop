using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStroe.Models
{
    public class OrderDetails
    {
        public int BookModelId { get; set; }
        public BookModel BookModel { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
