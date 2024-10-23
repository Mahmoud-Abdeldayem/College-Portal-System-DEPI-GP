using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTO
{
    public class UserViewDTO
    {
        public string Address { get; set; }
        public byte[]? Picture { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; } = null!;
        public string? Password { get; set; } = null!;

        public string? Role { get; set; } = null!;
        public string? NationalId { get; set; } = null!;
        public string? Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
