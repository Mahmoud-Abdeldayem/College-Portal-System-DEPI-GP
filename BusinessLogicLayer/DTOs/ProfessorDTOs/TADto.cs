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
    public class TADto : ApplicationUserDto
    {
        public string AssistingProfessorId { get; set; } = null!;
        public string AcademicDegree { get; set; } = null!;
        public int DepartmentId { get; set; }
        public string University { get; set; } = null!;       
        public string Faculty { get; set; } = null!;
    }
}
