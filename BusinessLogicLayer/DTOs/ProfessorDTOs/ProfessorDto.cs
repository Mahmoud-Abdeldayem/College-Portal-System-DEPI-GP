using BusinessLogicLayer.DTOs.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BusinessLogicLayer.DTOs.ProfessorDTOs
{
    public class ProfessorDto : ApplicationUserDto
    {
        public int DepartmentId { get; set; }
        public string DocUni { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string PHDField { get; set; } = null!;
    }
}
