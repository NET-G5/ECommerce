using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.ViewModels.Customer
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [MaxLength(50, ErrorMessage = "Max 50 characters allowed")]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Max 50 or Min 5 characters allowed.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
