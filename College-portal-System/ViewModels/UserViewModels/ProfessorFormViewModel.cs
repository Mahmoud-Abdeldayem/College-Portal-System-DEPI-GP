using College_portal_System.Consts;
using System.ComponentModel.DataAnnotations;

namespace College_portal_System.ViewModels.UserViewModels
{
    public class ProfessorFormViewModel : ApplicationUserFormVM
    {
        [Required(ErrorMessage = Errors.IsRequired)]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = Errors.IsRequired), MaxLength(40)]
        public string DocUni { get; set; } = null!;

        [Required(ErrorMessage = Errors.IsRequired), MaxLength(15)]
        public string Title { get; set; } = null!;
        [Required(ErrorMessage = Errors.IsRequired), MaxLength(50)]
        public string PHDField { get; set; } = null!;
    }
}
