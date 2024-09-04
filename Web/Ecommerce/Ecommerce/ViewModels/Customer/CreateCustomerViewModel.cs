using System.ComponentModel.DataAnnotations;

namespace Ecommerce.ViewModels.Customer
{
    public class CreateCustomerViewModel
    {
        [Required(ErrorMessage = "First name is required.")]
        [MaxLength(50, ErrorMessage = "Max 50 characters allowed.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [MaxLength(50, ErrorMessage = "Max 50 characters allowed.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [MaxLength(50, ErrorMessage = "Max 50 characters allowed.")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please, Enter valid Email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Max 50 or Min 5 characters allowed.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Please confirm your password.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Max 50 or Min 5 characters allowed.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public DateTime DateRegistered { get; set; }
    }
}
