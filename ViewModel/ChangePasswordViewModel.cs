using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStroe.ViewModel
{
    public class ChangePasswordViewModel
    {
        [Required,DataType(DataType.Password),Display(Name ="Current password")]
        public string CurrentPassword { get; set; }

        [Required, DataType(DataType.Password), Display(Name = "New password")]
        public string NewPassword { get; set; }

        [Required, DataType(DataType.Password), Display(Name = "Confirm password")]
        [Compare("NewPassword", ErrorMessage ="Confirm password doesn't match")]
        public string ConfirmPassword { get; set; }
    }
}
