using System.ComponentModel.DataAnnotations;

namespace College_portal_System.Models.StudentViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage ="Please Enter Your Address")]
        public string Address { get; set; }
        public byte[]? Picture { get; set; }
        [Required(ErrorMessage = "Please Enter Your First Name")]
        public string FirstName { get; set; } 
        [Required(ErrorMessage = "Please Enter Your Last Name")]
        public string LastName { get; set; }
        public string? Password { get; set; }

        public string? Role { get; set; }
        public string? NationalId { get; set; }
        public string? Gender { get; set; }
        [Required(ErrorMessage = "Please Enter Your Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Your Phone number")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone number must contain only numbers.")]
        public string Phone { get; set; }
    }
}
