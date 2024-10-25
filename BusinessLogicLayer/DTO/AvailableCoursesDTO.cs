using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTO
{
    public class AvailableCoursesDTO
    {
        public int EnrollmentId { get; set; }
        public int? CourseID { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }

    }
}
