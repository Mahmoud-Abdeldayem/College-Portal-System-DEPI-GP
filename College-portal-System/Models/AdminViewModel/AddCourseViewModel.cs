using College_portal_System.Utilities.Validations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace College_portal_System.Models.AdminViewModel
{
    public class AddCourseViewModel
    {
        [Required]
        [UniqueCourseName]
        public string CourseName { get; set; }

        [Required]
        [UniqueCourseCode]
        public string CourseCode { get; set; }


        [Range(1, 4, ErrorMessage = "College Credit hours are between 1 : 4 , review the college list")]
        public int Hours { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        public int? PrerequisiteCourseId {  get; set; }
        public List<SelectListItem>? PrerequisiteCourses { get; set; }

        public List<SelectListItem>? Departments { get; set; }


        [Range(1, 4 , ErrorMessage = "Course level must be between level : 1 to 4")]
        public int Level  { get; set; }

        //[Range(0 , 1, ErrorMessage = "There is only 2 semesters : 1 & 2")]
        public bool Semester { get; set; }
    }
}
