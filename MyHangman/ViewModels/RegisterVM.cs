using System.ComponentModel.DataAnnotations;

namespace MyHangman.ViewModels
{
    public class RegisterVM
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Password must be atleast 5 and characters long")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords does not match")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}