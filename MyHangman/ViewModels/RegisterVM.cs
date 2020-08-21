using System.ComponentModel.DataAnnotations;

namespace MyHangman.ViewModels
{
    public class RegisterVM
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(5, ErrorMessage = "Password must be minimum 5 characters long")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords does not match")]
        [StringLength(5, ErrorMessage = "Password must be minimum 5 characters long")]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }
    }
}