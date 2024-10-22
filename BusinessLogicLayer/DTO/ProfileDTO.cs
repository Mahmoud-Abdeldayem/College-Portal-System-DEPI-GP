using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTO
{
    public class ProfileDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RecoveryEmail { get; set; } = null!;

        public string Address { get; set; }
        public bool? Gender { get; set; }
        public byte[]? Picture { get; set; }
        public string StudentId { get; set; } = null!;

        public DateOnly EntryYear { get; set; }

        public DateOnly? GradYear { get; set; }

        public bool? CurrentState { get; set; }

        public bool? CollegeState { get; set; }

        public short? CurrentYear { get; set; }

        public decimal? TotalGpa { get; set; }

        public int HoursTaken { get; set; }

        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public string? NationalId { get; set; }
    }
}
