using BusinessLogicLayer.DTO;

namespace College_portal_System.Models.StudentViewModels
{
    public class RegisterDeptsViewModels
    {
        public int? StudentDepartment { get; set; }
        public List<DeptsDTO> Depts { get; set; } = new List<DeptsDTO>();
    }
}
