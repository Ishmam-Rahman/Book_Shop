using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStroe.ViewModel
{
    public class SignInUserViewModel
    {
        [Required(ErrorMessage = "Please enter a strong password")]
        public string Username { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remeber Me???")]
        public bool RememberMe { get; set; }
    }
}
