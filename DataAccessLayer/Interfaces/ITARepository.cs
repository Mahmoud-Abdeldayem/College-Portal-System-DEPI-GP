using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task = DataAccessLayer.Entities.Task;

namespace DataAccessLayer.Interfaces
{
    public interface ITARepository : IBaseRepository<TeachingAssistant>
    {
        IEnumerable<CourseTeaching> GetCourseTeachings(string teachingAssistantId);
        ApplicationUser GetTAGeneralData(string id);
        ApplicationUser UpdateProfileInfo(ApplicationUser TA);

        List<Task> GetAllTATasks(string taId);
    }
}
