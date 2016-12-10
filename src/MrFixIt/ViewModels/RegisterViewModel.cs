using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MrFixIt.ViewModels
{
    //we using viewModel so that Ef(Entity framwork) won't create a new talbe in the database to represent this data
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        //need to add [Required] to make sure confirm password match! & add error page in controller if it's not match
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        //This doesn't send error message 
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
//next create register viewpage using FormMethod.Post. The Post action in view page will takes these info submitted from the form to create a new user, then we need to create register Post action in controller