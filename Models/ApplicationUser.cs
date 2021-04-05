using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStroe.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        [Display(Name = "Your Last Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Your First Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Enter Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Birth Date")]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }
    }
}
