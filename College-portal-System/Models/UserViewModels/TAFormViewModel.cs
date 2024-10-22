namespace College_portal_System.Models.UserViewModels
{
    public class TAFormViewModel : ApplicationUserFormVM
    {
        public string AssistingProfessorId { get; set; } = null!;
        public string AcademicDegree { get; set; } = null!;
        public int DepartmentId {  get; set; }
        public string University { get; set; } = null!;
    }
}
