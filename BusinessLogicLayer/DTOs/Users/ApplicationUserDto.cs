using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs.Users
{
    public class ApplicationUserDto
    {
        public string? UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string NationalId { get; set; } = null!;
        public string? Address { get; set; }
        public byte[]? Picture { get; set; }
        public string Gender { get; set; }= null!;
        public string? PhoneNumber { get; set; }
        public string SelectedRole { get; set; } = null!;
    }
}
