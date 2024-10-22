using BusinessLogicLayer.AdminService.Services;
using DataAccessLayer.UnitOfWork;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Printing;

namespace College_portal_System.Utilities.Validations
{
    public class UniqueCourseNameAttribute : ValidationAttribute
    {
        public UniqueCourseNameAttribute()
        {
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string currentCourse = value as string;
            var httpContextAccessor = (IHttpContextAccessor)validationContext.GetService(typeof(IHttpContextAccessor));
            var adminService = httpContextAccessor.HttpContext.RequestServices.GetService<AdminService>();
            if (string.IsNullOrEmpty(currentCourse))
            {
                return new ValidationResult("Course Name is required");
            }
            else
            {
                var course = adminService.GetCourseByName(currentCourse);
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
