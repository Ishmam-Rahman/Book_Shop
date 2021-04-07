using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookStroe.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        [Required]
        [Display(Name = "Name")]
        public String Name { get; set; }
        [Required]
        [Display(Name = "Phone No")]
        public String Phone { get; set; }
        [Required]
        [EmailAddress]
        public String Email { get; set; }
        [Required]
        public String Address { get; set; }
        public DateTime OrderDate { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
