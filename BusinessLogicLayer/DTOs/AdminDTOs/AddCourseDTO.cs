using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs.AdminDTOs
{
    public class AddCourseDTO
    {
        public int CourseId { get; set; }

        public string Name { get; set; } = null!;

        public string Code { get; set; } = null!;

        public int Hours { get; set; }

        public int? PrerequisiteCourseId { get; set; }

        public bool Semseter { get; set; }

        public int CourseLevel { get; set; }

        public int? DepartmentId { get; set; }
    }
}
