using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStroe.ViewModel
{
    public class SignUpUserViewModel
    {
        [Required(ErrorMessage = "Please enter your First Name")]
        [Display(Name = "Your First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your Last Name")]
        [Display(Name = "Your Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your Address")]
        [Display(Name = "Enter Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter your BirthDate")]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage ="Please enter your email")]
        [Display(Name ="Email address")]
        [EmailAddress(ErrorMessage ="Please enter a valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a strong password")]
        [Compare("ConfirmPassword",ErrorMessage ="Password doesn't match")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confrim your password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
