using System.ComponentModel.DataAnnotations;
using College_portal_System.Utilities.Validations;
namespace College_portal_System.Models.TAViewModels
{
    public class UpdateProfileViewModel
    {
        
        public string NationalID { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "First Name shouldn't exceed 20 characters")]
        [MinLength(2, ErrorMessage = "First Name should contains at least 2 characters")]
        public string FName { get; set; }

        [Required]
        [MaxLength(60, ErrorMessage = "Last Name shouldn't exceed 60 characters")]
        [MinLength(2, ErrorMessage = "Last Name should contains at least 2 characters")]
        public string LName { get; set; }

        [Required]
        [MaxLength(60 , ErrorMessage = "The address shouldn't exceed 60 characters")]
        [MinLength(2 , ErrorMessage = "The address contains at least 2 characters")]
        public string Address { get; set; }

        public string? ImageBase64 { get; set; }

        
        [ImageValidation(ErrorMessage = "Only JPG , PNG and JPEG are the accepted file extentions")]
        public IFormFile? Image { get; set; }

        [Required]
        [MinLength(8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\$@%#]).{8,}$", ErrorMessage = "Password must contain at least one lowercase letter, one uppercase letter, one number, and one special character")]
        public string Password { get; set; }

        [Required]
        [ComparePassword("Password" , ErrorMessage = "The Re-entered password doesn't match the first one")]
        public string Repassword { get; set; } 

    }
}
