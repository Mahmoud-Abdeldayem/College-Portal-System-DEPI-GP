using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class TARepository : ITARepository 
    {
        private readonly AppDbContext _context;
        public TARepository(AppDbContext context)
        {
            _context = context;
        }
        public TeachingAssistant Delete(TeachingAssistant Entity)
        {
            throw new NotImplementedException();
        }

        public TeachingAssistant DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TeachingAssistant> Get(Expression<Func<TeachingAssistant, bool>> criteria)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TeachingAssistant> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Entities.Task> GetAllTATasks(string taId)
        {
            var tasks = _context.Tasks.Include(t => t.Course).Where(t => t.AssignedByTaid == taId);
            return tasks.ToList();  
        }

        public TeachingAssistant GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CourseTeaching> GetCourseTeachings(string teachingAssistantId)
        {
            var teachingAssistantCourses = _context.CourseTeachings.Where(ta => ta.Taid == teachingAssistantId)
                                                             .Include(c => c.Course)
                                                             .Include(c => c.Professor)
                                                             .ThenInclude(p => p.ProfessorNavigation);
            return teachingAssistantCourses;
        }

        public ApplicationUser GetTAGeneralData(string id)
        {
            var taGenData = _context.ApplicationUsers.FirstOrDefault(a => a.NationalId == id);
            return taGenData;
        }

        public TeachingAssistant Insert(TeachingAssistant entity)
        {
            _context.TeachingAssistants.Add(entity);
            return entity;
        }

        public TeachingAssistant Update(TeachingAssistant entity)
        {
            _context.Update(entity);
            var ta = _context.TeachingAssistants.FirstOrDefault(a => a.Taid == entity.Taid);
            return ta;
        }

        public ApplicationUser UpdateProfileInfo(ApplicationUser TA)
        {
            // These Data musn't be updated from the BLL
            var oldTAData = _context.ApplicationUsers.Find(TA.NationalId);
            TA.FirstName = oldTAData.FirstName;
            TA.LastName = oldTAData.LastName;
            TA.Gender = oldTAData.Gender;
            TA.Role = oldTAData.Role;
            
            _context.ApplicationUsers.Update(TA);
            return oldTAData;
        }
    }
}
