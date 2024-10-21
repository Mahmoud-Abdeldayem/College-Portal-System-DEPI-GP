using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace College_portal_System.Models.AdminViewModel
{
    public class AddCourseViewModel
    {
        [Required]
        public string CourseName { get; set; }

        [Required]
        public string CourseCode { get; set; }


        [Range(1, 4, ErrorMessage = "College Credit hours are between 1 : 4 , review the college list")]
        public int Hours { get; set; }

        public List<SelectListItem>? PrerequisiteCourse { get; set; }

        public List<SelectListItem> Department { get; set; }

        [Range(1, 4 , ErrorMessage = "Course level must be between level : 1 to 4")]
        public int Level  { get; set; }

        [Range(1, 2, ErrorMessage = "There is only 2 semesters : 1 & 2")]
        public int Semester { get; set; }
    }
}
