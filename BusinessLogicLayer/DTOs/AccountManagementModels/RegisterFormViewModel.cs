using System.ComponentModel.DataAnnotations;

namespace College_portal_System.Models.AdminViewModels
{
    public class RegisterFormViewModel
    {
        [Required, MaxLength(50)]
        public string FirstName { get; set; } = null!;

        [Required, MaxLength(50)]
        public string LastName { get; set; } = null!;
        [Required, MaxLength(120)]
        public string Email { get; set; } = null!;

        //[Required, MaxLength(14), RegularExpression(RegexPatterns.NationalIdFormat)]
        public string NationalId { get; set; } = null!;

        [Required, MaxLength(10)]
        public string Gender { get; set; } = null!;

        [Required, MaxLength(120)]
        public string Address { get; set; } = null!;

        [Required, MaxLength(13)]
        public string PhoneNumber { get; set; } = null!;

        //[Required, RegularExpression(RegexPatterns.Password_LowercaseAndDigits)]
        public string Password { get; set; } = null!;

        [Required]
        public string SelectedRole { get; set; } = null!;

        public byte[]? Picture { get; set; }
    }
}
