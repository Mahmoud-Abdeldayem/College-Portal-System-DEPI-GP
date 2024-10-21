using System.ComponentModel.DataAnnotations;
using BusinessLogicLayer.AdminService;
namespace College_portal_System.Utilities.Validations
{
    public class ExistedCourseNameAttribute : ValidationAttribute
    {
        private readonly string _courseName;
        public ExistedCourseNameAttribute(string courseName)
        {
            _courseName = courseName;
        }

        public override bool IsValid(object? value)
        {
            //var course = Adm
            return true;
        }
    }
}
