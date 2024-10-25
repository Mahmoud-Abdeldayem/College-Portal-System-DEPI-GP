using DataAccessLayer.Entities;
namespace College_portal_System.ViewModels.AdminViewModels
{
    public class StudentOverviewModel
    {
        public List<Student>? Students { get; set; }
        public List<Professor>? Professors { get; set; }
        public List<TeachingAssistant>? TeachingAssistants { get; set; }
    }
}
