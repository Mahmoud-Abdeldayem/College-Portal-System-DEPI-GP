using BusinessLogicLayer.AdminService.Services;
using System.ComponentModel.DataAnnotations;

namespace College_portal_System.Utilities.Validations
{
    public class UniqueCourseCode : ValidationAttribute
    {
        public UniqueCourseCode() 
        {

        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string currentCourse = value as string;
            var httpContextAccessor = (IHttpContextAccessor)validationContext.GetService(typeof(IHttpContextAccessor));
            var adminService = httpContextAccessor.HttpContext.RequestServices.GetService<AdminService>();
            if (string.IsNullOrEmpty(currentCourse))
            {
                return new ValidationResult("Course Code is required");
            }
            else
            {
                var course = adminService.GetCourseByCode(currentCourse);
                if (course != null)
                {
                    return new ValidationResult("This course already exist");
                }
                // course is null => no course with 
                return ValidationResult.Success;
            }
        }
    }
}
