using College_portal_System.Consts;
using System.ComponentModel.DataAnnotations;

namespace College_portal_System.ViewModels.UserViewModels
{
    public class TAFormViewModel : ApplicationUserFormVM
    {
        [Required(ErrorMessage = Errors.IsRequired)]
        public string AssistingProfessorId { get; set; } = null!;
        [Required(ErrorMessage = Errors.IsRequired)]
        public string AcademicDegree { get; set; } = null!;
        [Required(ErrorMessage = Errors.IsRequired)]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = Errors.IsRequired)]
        public string University { get; set; } = null!;
        [Required(ErrorMessage = Errors.IsRequired)]
        public string Faculty { get; set; } = null!;
    }
}
