﻿using College_portal_System.Consts;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace College_portal_System.Models.UserViewModels
{
    public class ApplicationUserFormVM
    {
        [Required]
        public string UserId { get; set; } = null!;
        [Required, MaxLength(120)]
        public string FirstName { get; set; } = null!;
        [Required, MaxLength(120)]
        public string LastName { get; set; } = null!;

        [Required, MaxLength(150), EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(100,MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        [Required, RegularExpression(RegexPatterns.NationalIdFormat)]
        public string NationalId { get; set; } = null!;
        [Required]
        public string? Address { get; set; }
        public byte[]? Picture { get; set; }
        [Required(ErrorMessage = "Please Enter The Gender!")]
        public string Gender { get; set; } = null!;
        [Required]
        public string PhoneNumber { get; set; } = null!;
        [Required(ErrorMessage = "Please Enter The Role!")]
        public string SelectedRole { get; set; } = null!;
    }
}