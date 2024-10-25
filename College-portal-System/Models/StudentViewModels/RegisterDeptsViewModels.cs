using BusinessLogicLayer.DTO;
using System.ComponentModel.DataAnnotations;

namespace College_portal_System.Models.StudentViewModels
{
    public class RegisterDeptsViewModels
    {
        [Required(ErrorMessage ="Please Choose Department")]
        public int? StudentDepartment { get; set; }
        public int? CurrentYear { get; set; }
        public List<DeptsDTO> Depts { get; set; } = new List<DeptsDTO>();
    }
}
