using System.ComponentModel.DataAnnotations;

namespace College_portal_System.ViewModels.UserViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
     
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
