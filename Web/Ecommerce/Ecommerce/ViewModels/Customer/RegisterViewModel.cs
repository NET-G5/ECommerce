using System.ComponentModel.DataAnnotations;

namespace Ecommerce.ViewModels.Customer
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "First Name is required")]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public required string LastName { get; set; }


        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        public required string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public required string ConfirmPassword { get; set; }

    }
}
